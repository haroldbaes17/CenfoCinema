﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAO;
using DTOs;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {

        public UserCrudFactory()
        {
            _sqlDao = SqlDao.GetInstance();
        }
        public override void Create(BaseDto baseDto)
        {
            var user = baseDto as User;

            var sqlOperation = new SqlOperation() { ProcedureName = "CRE_USER_PR" };
            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);
            sqlOperation.AddStringParameter("P_Status", "Activo"); // Estado por defecto al crear un usuario

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseDto baseDto)
        {
            var user = baseDto as User;

            var sqlOperation = new SqlOperation() { ProcedureName = "UPD_USER_PR" };
            sqlOperation.AddIntParam("P_Id", user.Id);
            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);
            sqlOperation.AddStringParameter("P_Status", user.Status);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDto baseDto)
        {
            var user = baseDto as User;

            var sqlOperation = new SqlOperation() { ProcedureName = "DEL_USER_PR" };
            sqlOperation.AddIntParam("P_Id", user.Id);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int Id)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_ID_PR" };
            sqlOperation.AddIntParam("P_Id", Id);
            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }

            return default(T);
        }

        public  T RetrieveByUserCode<T>(User user)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_CODE_PR" };
            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }

            return default(T);
        }

        public T RetrieveByEmail<T>(User user)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_EMAIL_PR" };
            sqlOperation.AddStringParameter("P_Email", user.Email);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_ALL_USERS_PR" };
            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if(lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var user = BuildUser(row);
                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }

            return lstUsers;
        }

        //Metodo que convierte el diccionario en un usuario
        private User BuildUser(Dictionary<string, object> row)
        {
            var user = new User
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                //Updated = (DateTime)row["Updated"],
                UserCode = (string)row["UserCode"],
                Name = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                BirthDate = (DateTime)row["BirthDate"],
                Status = (string)row["Status"]
            };
            return user;
        }
    }
}
