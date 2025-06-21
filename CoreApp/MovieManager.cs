using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CRUD;
using DotNetEnv;
using DTOs;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CoreApp
{
    public class MovieManager : BaseManager
    {

        /*
         * Metodo para la creacion de una película
         * =================================================
         * Valida que la pelicula no este registrada
         * Envia un email a todos los usuarios con info del nuevo titulo
         * =================================================
         */

        public void Create(Movie movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();

                //Validaciones

                //Validar si el titulo ya existe
                var titleExist = mCrud.RetrieveByTitle<Movie>(movie);

                if (titleExist != null)
                {
                    throw new Exception("El título de la película ya está registrado.");
                }

                mCrud.Create(movie);

                //Enviar correo a todos los usuarios con la información del nuevo título
                var uCrud = new UserCrudFactory();
                var lstUsers = uCrud.RetrieveAll<User>();
                SendEmailToUsers(movie, lstUsers);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        async Task SendEmailToUsers(Movie movie, List<User> lstUsers)
        {
            
            foreach (var user in lstUsers)
            {
                Env.Load();
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                if (string.IsNullOrEmpty(apiKey))
                    throw new InvalidOperationException("Falta la clave SENDGRID_API_KEY en el entorno.");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("hbarrantese@ucenfotec.ac.cr", "Harold Barrantes");
                var subject = $"Nueva Pelicula en estreno!";
                var to = new EmailAddress(user.Email, user.Name);
                var plainTextContent = $"Hola {user.Name},\n\n¡Tenemos un nuevo estreno en cartelera!\nTe invitamos a disfrutar de nuestra más reciente película. No te lo pierdas.\n\nSaludos,\nCenfoCinemas Team";
                var htmlContent = $"<strong>Hola {user.Name},</strong><br><br>¡Tenemos un nuevo estreno en cartelera!<br>Te invitamos a disfrutar de nuestra más reciente película. No te lo pierdas.<br><br>Saludos,<br>CenfoCinemas Team";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            }
        }

    }
}
