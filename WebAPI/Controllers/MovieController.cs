using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Movie movie)
        {
            try
            {
                var uManager = new MovieManager();
                uManager.Create(movie);
                return Ok(movie);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var mManager = new MovieManager();
                var listResults = mManager.RetrieveAll();

                return Ok(listResults);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(int id)
        {
            try
            {
                var mManager = new MovieManager();
                var movie = new Movie { Id = id };
                movie = mManager.RetrieveById(movie);

                if (movie == null)
                {
                    throw new Exception("Película no encontrada.");
                }

                return Ok(movie);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByTitle")]
        public ActionResult RetrieveByTitle(string title)
        {
            try
            {
                var mManager = new MovieManager();
                var movie = new Movie { Title = title };
                movie = mManager.RetrieveByTitle(movie);

                if (movie == null)
                {
                    throw new Exception("Película no encontrada.");
                }
                return Ok(movie);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Movie movie)
        {
            try
            {
                var mManager = new MovieManager();
                mManager.Update(movie);
                return Ok(movie);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Movie movie)
        {
            try
            {
                var mManager = new MovieManager();
                mManager.Delete(movie);
                return Ok("Pelicula eliminada correctamente.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
