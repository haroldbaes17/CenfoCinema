// JS que manejaa todo el comportamiento de la vista de usuarios

// Definir una clase JS, usando prototype

function UsersViewController() {
    this.ViewName = "Users";
    this.APIEndpoint = "User";

    //Metodo constructor
    this.InitView = function () {
        console.log("User init view --> ok");
        this.LoadTable();
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
        })
    }

}

$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
})