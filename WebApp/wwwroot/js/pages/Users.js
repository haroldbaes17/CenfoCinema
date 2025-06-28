// JS que manejaa todo el comportamiento de la vista de usuarios

// Definir una clase JS, usando prototype

function UsersViewController() {
    this.ViewName = "Users";
    this.APIEndpoint = "User";

    //Metodo constructor
    this.InitView = function () {
        console.log("User init view --> ok");
        this.LoadTable();

        //Asociar el evento al boton 
        $("#btnCreate").click(function() {
            var vc = new UsersViewController();
            vc.Create();
        });

        $("#btnUpdate").click(function () {
            var vc = new UsersViewController();
            vc.Update();
        });

        $("#btnDelete").click(function () {
            var vc = new UsersViewController();
            vc.Delete();
        });
    }

    //Metodo para la carga de una tabla 
    this.LoadTable = function () {

        //URL del API a invocar
        //'https://localhost:7285/api/Movie/RetrieveAll'

        var ca = new ControlActions();
        var service = this.APIEndpoint + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*
         {
            "userCode": "Haroldbe17",
            "name": "Harold Barrantes",
            "email": "hbarrantese@ucenfotec.ac.cr",
            "password": "12345678",
            "birthDate": "2005-12-17T03:54:01.63",
            "status": "Activo",
            "id": 25,
            "created": "2025-06-22T03:55:28.407",
            "updated": "0001-01-01T00:00:00"
         }

         <tr>
						<th>Id</th>
						<th>User Code</th>
						<th>Name</th>
						<th>Email</th>
						<th>Birth Date</th>
						<th>Status</th>
					</tr>
        */

        var colums = [];
        colums[0] = { 'data': 'id' };
        colums[1] = { 'data': 'userCode' };
        colums[2] = { 'data': 'name' };
        colums[3] = { 'data': 'email' };
        colums[4] = { 'data': 'birthDate' };
        colums[5] = { 'data': 'status' };

        //Invocamos a dataTable para convertir la tabla simple HTML en una tabla mas robusta
        $("#tblUsers").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": colums,
        });

        //Asignar eventos de carga de datos o binding segun el click en la tabla
        $("#tblUsers tbody").on("click",
            "tr",
            function() {
                //Extraemos la fila
                var row = $(this).closest("tr");

                //Extraemos el dto
                //Esto nos devuelve el JSON de la fila seleccionada por el usuario
                //Segun la data devuelta por el API
                var userDto = $("#tblUsers").DataTable().row(row).data();

                //Binding con el form
                $("#txtId").val(userDto.id);
                $("#txtUserCode").val(userDto.userCode);
                $("#txtName").val(userDto.name);
                $("#txtEmail").val(userDto.email);
                $("#txtStatus").val(userDto.status);

                //Fecha tiene un formato
                var onlyDate = userDto.birthDate.split("T");
                $("#txtBirthDate").val(onlyDate[0]);

            });
    }

    this.Create = function() {
        var userDto = {}

        //Atributos con valores default, que son controlados por el API
        userDto.id = 0;
        userDto.created = "2025-01-01";
        userDto.updated = "2025-01-01";

        //Valores capturados en pantalla
        userDto.userCode = $("#txtUserCode").val();
        userDto.name = $("#txtName").val();
        userDto.email = $("#txtEmail").val();
        userDto.status = $("#txtStatus").val();
        userDto.birthDate = $("#txtBirthDate").val();
        userDto.password = $("#txtPassword").val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.APIEndpoint + "/Create";

        ca.PostToAPI(urlService,
            userDto,
            function() {
                //Recargo de la tabla
                $("#tblUsers").DataTable().ajax.reload(); 
            });
    }

    this.Update = function() {
        var userDto = {}

        //Atributos con valores default, que son controlados por el API
        userDto.id = $("#txtId").val() ;
        userDto.created = "2025-01-01";
        userDto.updated = "2025-01-01";

        //Valores capturados en pantalla
        userDto.userCode = $("#txtUserCode").val();
        userDto.name = $("#txtName").val();
        userDto.email = $("#txtEmail").val();
        userDto.status = $("#txtStatus").val();
        userDto.birthDate = $("#txtBirthDate").val();
        userDto.password = $("#txtPassword").val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.APIEndpoint + "/Update";

        ca.PutToAPI(urlService,
            userDto,
            function() {
                //Recargo de la tabla
                $("#tblUsers").DataTable().ajax.reload(); 
            });
    }

    this.Delete = function () {
        var userDto = {}

        //Atributos con valores default, que son controlados por el API
        userDto.id = $("#txtId").val();
        userDto.created = "2025-01-01";
        userDto.updated = "2025-01-01";

        //Valores capturados en pantalla
        userDto.userCode = $("#txtUserCode").val();
        userDto.name = $("#txtName").val();
        userDto.email = $("#txtEmail").val();
        userDto.status = $("#txtStatus").val();
        userDto.birthDate = $("#txtBirthDate").val();
        userDto.password = $("#txtPassword").val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.APIEndpoint + "/Delete";

        ca.DeleteToAPI(urlService,
            userDto,
            function () {
                //Recargo de la tabla
                $("#tblUsers").DataTable().ajax.reload();
            });
    }
}


$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
})