using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //Indicamos que la direccion de este controlador
    //sera http://servidor-puerto/api/user
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(User user)
        {
            try
            {
                var uManager  = new UserManager();
                uManager.Create(user);
                return Ok(user);
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
                var uManager = new UserManager();
                var listResults = uManager.RetrieveAll();

                return Ok(listResults);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(User user)
        {
            try
            {
                var uManager = new UserManager();
                var userFound = uManager.RetrieveById(user);

                if (userFound == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                return Ok(userFound);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("RetrieveByUserCode")]
        public ActionResult RetrieveByUserCode(User user)
        {
            try
            {
                var uManager = new UserManager();
                var userFound = uManager.RetrieveByUserCode(user);

                if (userFound == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                return Ok(userFound);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("RetrieveByEmail")]
        public ActionResult RetrieveByEmail(User user)
        {
            try
            {
                var uManager = new UserManager();
                var userFound = uManager.RetrieveByEmail(user);

                if (userFound == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                return Ok(userFound);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(User user)
        {
            try
            {
                var uManager = new UserManager();
                uManager.Update(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(User user)
        {
            try
            {
                var uManager = new UserManager();
                uManager.Delete(user);
                return Ok("Usuario eliminado correctamente.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
