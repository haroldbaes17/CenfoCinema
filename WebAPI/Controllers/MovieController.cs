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

        [HttpPost]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(Movie movie)
        {
            try
            {
                var mManager = new MovieManager();
                var movieFound = mManager.RetrieveById(movie);

                if (movieFound == null)
                {
                    throw new Exception("Película no encontrada.");
                }

                return Ok(movieFound);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("RetrieveByTitle")]
        public ActionResult RetrieveByTitle(Movie movie)
        {
            try
            {
                var mManager = new MovieManager();
                var movieFound = mManager.RetrieveByTitle(movie);
                if (movieFound == null)
                {
                    throw new Exception("Película no encontrada.");
                }
                return Ok(movieFound);
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
