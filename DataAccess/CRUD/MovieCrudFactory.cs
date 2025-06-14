using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAO;
using DTOs;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public override void Create(BaseDto baseDto)
        {
            var movie = baseDto as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_MOVIE_PR";

            sqlOperation.AddStringParameter("P_Title", movie.Title);
            sqlOperation.AddStringParameter("P_Description", movie.Description);
            sqlOperation.AddStringParameter("P_Genre", movie.Genre);
            sqlOperation.AddDateTimeParam("P_ReleaseDate", movie.ReleaseDate);
            sqlOperation.AddStringParameter("P_Director", movie.Director);

            var sqlDao = SqlDao.GetInstance();
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseDto baseDto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseDto baseDto)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int Id)
        {
            var lstMovie = new List<T>();
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_MOVIEBYID_PR" };
            sqlOperation.AddIntParam("P_Id", Id);
            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var movie = BuildMovie(row);
                lstMovie.Add((T)Convert.ChangeType(movie, typeof(T)));
            }
            return lstMovie.Count > 0 ? lstMovie[0] : default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_ALL_MOVIES_PR" };
            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var movie = BuildMovie(row);
                    lstMovies.Add((T)Convert.ChangeType(movie, typeof(T)));
                }
            }
            return lstMovies;
        }

        //Metodo que convierte el diccionario en una movie  
        private Movie BuildMovie(Dictionary<string, object> row)
        {
            var movie = new Movie
            {
                Id = Convert.ToInt32(row["Id"]),
                Created = (DateTime)row["Created"],
                //Updated = (DateTime)row["Updated"],
                Title = Convert.ToString(row["Title"]),
                Description = Convert.ToString(row["Description"]),
                Genre = Convert.ToString(row["Genre"]),
                ReleaseDate = Convert.ToDateTime(row["ReleaseDate"]),
                Director = Convert.ToString(row["Director"])
            };
            return movie;
        }
    }
}
