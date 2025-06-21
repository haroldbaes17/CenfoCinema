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

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(int id)
        {
            try
            {
                var uManager = new UserManager();
                var user = new User { Id = id }; 
                user = uManager.RetrieveById(user);

                if (user == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                return Ok(user);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByUserCode")]
        public ActionResult RetrieveByUserCode(string userCode)
        {
            try
            {
                var uManager = new UserManager();
                var user = new User { UserCode = userCode };
                user  = uManager.RetrieveByUserCode(user);

                if (user == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByEmail")]
        public ActionResult RetrieveByEmail(string email)
        {
            try
            {
                var uManager = new UserManager();
                var user = new User { Email = email };
                 user = uManager.RetrieveByEmail(user);

                if (user == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                return Ok(user);
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
