using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CRUD;
using DTOs;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;
using DotNetEnv;



namespace CoreApp
{
    public class UserManager : BaseManager
    {
        /*
         * Metodo para la creacion de un usuario
         * =================================================
         * Valida que el usuario sea mayor de 18 años.
         * Valida que el codigo de usuario este disponible.
         * Valida que el correo electronico no este registrado.
         * Envia un correo electronico de bienvenida al usuario.
         * =================================================
         */
        public void Create(User user)
        {
            try
            {
                var uCrud = new UserCrudFactory();

                //Validaciones

                //Validar la edad
                if (!IsOver18(user))
                {
                    throw new Exception("Usuario no cumple con la edad minima.");
                }

                //Validacion si el usuario ya existe
                var userCodeExist = uCrud.RetrieveByUserCode<User>(user);
                if (userCodeExist != null)
                {
                    throw new Exception("El codigo de usuario ya esta en uso.");
                }

                //Validacion si el correo ya existe
                var emailExist = uCrud.RetrieveByEmail<User>(user);
                if (emailExist != null)
                {
                    throw new Exception("El correo electronico ya esta registrado.");
                }

                uCrud.Create(user);

                //Enviar correo de bienvenida
                SendWelcomeEmail(user);
                

            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<User> RetrieveAll()
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAll<User>();
        }

        public User RetrieveById(User user)
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveById<User>(user.Id);
        }

        public User RetrieveByUserCode(User user)
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveByUserCode<User>(user);
        }

        public User RetrieveByEmail(User user)
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveByEmail<User>(user);
        }

        public void Update(User user)
        {
            try
            {
                var uCrud = new UserCrudFactory();
                uCrud.Update(user);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Delete(User user)
        {
            try
            {
                var uCrud = new UserCrudFactory();
                uCrud.Delete(user);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if(user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }

        private async Task SendWelcomeEmail(User user)
        {
            Env.Load(Path.Combine(AppContext.BaseDirectory, ".env"));

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("Falta la clave SENDGRID_API_KEY en el entorno.");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("hbarrantese@ucenfotec.ac.cr", "Harold Barrantes");
            var subject = $"Bienvenido a CenfoCinemas, es un placer conocerte, {user.Name}!";
            var to = new EmailAddress(user.Email, user.Name);
            var plainTextContent = $"Hola {user.Name},\n\nGracias por registrarte en CenfoCinemas. Estamos emocionados de tenerte con nosotros.\n\nSaludos,\nCenfoCinemas Team";
            var htmlContent = $"<strong>Hola {user.Name},</strong><br><br>Gracias por registrarte en CenfoCinemas. Estamos emocionados de tenerte con nosotros.<br><br>Saludos,<br>CenfoCinemas Team";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
