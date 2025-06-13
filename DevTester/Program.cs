using System.Text.Json.Serialization;
using DataAccess.CRUD;
using DataAccess.DAO;
using DTOs;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {

        while (true)
        {
            Console.WriteLine("1. Agregar una película");
            Console.WriteLine("2. Actualizar una película");
            Console.WriteLine("3. Agregar un Usuario");
            Console.WriteLine("4. Actualizar un Usuario");
            Console.WriteLine("5. Eliminar Usuario");
            Console.WriteLine("6. Consultar Usuarios");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");
            int input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    agregarPelicula();
                    break;
                case 2:
                    actualizarPelicula();
                    break;
                case 3:
                    agregarUsuario();
                    break;
                case 4:
                    actualizarUsuario();
                    break;
                case 5:                
                    eliminarUsuario();
                    break;
                case 6:
                    listarUsuarios();
                    break;

                case 9:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default: 
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

    }

    private static void agregarPelicula()
    {
        //Informacion de la película

        Console.Write("Ingrese el título de la película: ");
       var titulo = Console.ReadLine();

       Console.Write("Ingrese la descripción de la película: ");
       var descripcion = Console.ReadLine();

       Console.Write("Ingrese el genero de la película: ");
       var genero = Console.ReadLine();

       Console.Write("Ingrese el director de la pelicula: ");
       var director = Console.ReadLine();

        //Logica para agregar la película
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "CRE_MOVIE_PR";

        sqlOperation.AddStringParameter("P_Title", titulo);
        sqlOperation.AddStringParameter("P_Description", descripcion);
        sqlOperation.AddStringParameter("P_Genre", genero);
        sqlOperation.AddDateTimeParam("P_ReleaseDate", DateTime.Now);
        sqlOperation.AddStringParameter("P_Director", director);

        var sqlDao = SqlDao.GetInstance();
        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Película agregada exitosamente.");
    }

    private static void actualizarPelicula()
    {
        //Informacion de la película
        Console.Write("Ingrese el ID de la película a actualizar: ");
        var id = Int32.Parse(Console.ReadLine());

        Console.Write("Ingrese el nuevo título de la película: ");
        var titulo = Console.ReadLine();

        Console.Write("Ingrese la nueva descripción de la película: ");
        var descripcion = Console.ReadLine();

        Console.Write("Ingrese el nuevo genero de la película: ");
        var genero = Console.ReadLine();

        Console.Write("Ingrese el nuevo director de la pelicula: ");
        var director = Console.ReadLine();

        //Logica para actualizar la película
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "UPD_MOVIE_PR";
        sqlOperation.AddIntParam("P_Id", id);
        sqlOperation.AddStringParameter("P_Title", titulo);
        sqlOperation.AddStringParameter("P_Description", descripcion);
        sqlOperation.AddStringParameter("P_Genre", genero);
        sqlOperation.AddStringParameter("P_Director", director);

        var sqlDao = SqlDao.GetInstance();
        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Película actualizada exitosamente.");
    }

    private static void agregarUsuario()
    {
        //Informacion del usuario
        Console.Write("Ingrese el Codigo del usuario: ");
        var codigo = Console.ReadLine();

        Console.Write("Ingrese el nombre del usuario: ");
        var nombre = Console.ReadLine();

        Console.Write("Ingrese el correo del usuario: ");
        var correo = Console.ReadLine();

        Console.Write("Ingrese la contraseña del usuario: ");
        var contrasena = Console.ReadLine();

        Console.Write("Ingrese la fecha de nacimiento (YYYY, MM, DD): ");
        var fechaNacimiento = DateTime.Parse(Console.ReadLine());

        //Logica para agregar el usuario

        //Creamos el objeto del usuario a partir de los objetos capturados en consola
        var user = new User()
        {
            UserCode = codigo,
            Name = nombre,
            Email = correo,
            Password = contrasena,
            BirthDate = fechaNacimiento,
            Status = "Activo" // Estado por defecto
        };

        var uCrud = new UserCrudFactory();
        uCrud.Create(user);

        Console.WriteLine("Usuario agregado exitosamente.");
    }

    private static void actualizarUsuario()
    {
        //Informacion del usuario
        Console.Write("Ingrese el ID del usuario a actualizar: ");
        var id = Int32.Parse(Console.ReadLine());

        Console.Write("Ingree el nuevo código del usuario: ");
        var codigo = Console.ReadLine();

        Console.Write("Ingrese el nuevo nombre del usuario: ");
        var nombre = Console.ReadLine();

        Console.Write("Ingrese el nuevo correo del usuario: ");
        var correo = Console.ReadLine();

        Console.Write("Ingrese la nueva contraseña del usuario: ");
        var contrasena = Console.ReadLine();

        Console.Write("Ingrese la nueva fecha de nacimiento (YYYY, MM, DD): ");
        var fechaNacimiento = DateTime.Parse(Console.ReadLine());

        Console.Write("Ingrese el nuevo estado (Activo/Inactivo): ");
        var estado = Console.ReadLine();

        //Logica para actualizar el usuario
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "UPD_USER_PR";
        sqlOperation.AddIntParam("P_Id", id);
        sqlOperation.AddStringParameter("P_UserCode", codigo);
        sqlOperation.AddStringParameter("P_Name", nombre);
        sqlOperation.AddStringParameter("P_Email", correo);
        sqlOperation.AddStringParameter("P_Password", contrasena);
        sqlOperation.AddDateTimeParam("P_BirthDate", fechaNacimiento);
        sqlOperation.AddStringParameter("P_Status", estado);

        var sqlDao = SqlDao.GetInstance();
        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Usuario actualizado exitosamente.");
    }

    private static void eliminarUsuario()
    {
        Console.Write("Ingrese el ID del Usuario a eliminar: ");
        var id = Int32.Parse(Console.ReadLine());

        //Logica para eliminar el usuario
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "DEL_USER_PR";
        sqlOperation.AddIntParam("P_Id", id);

        var sqlDao = SqlDao.GetInstance();
        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Usuario eliminado exitosamente.");
    }

    private static void listarUsuarios()
    {
        var uCrud = new UserCrudFactory();
        var listUsers = uCrud.RetrieveAll<User>();

        foreach (var u in listUsers)
        {
            Console.WriteLine(JsonConvert.SerializeObject(u));
        }
    }
}