function MoviesViewController() {
    this.ViewName = "Movies";
    this.APIEndpoint = "Movie";

    this.InitView = function () {
        console.log("Movies init view --> ok");
        this.LoadTable();

        //Asociar el evento al boton 
        $("#btnCreate").click(function () {
            var vc = new MoviesViewController();
            vc.Create();
        });

        $("#btnUpdate").click(function () {
            var vc = new MoviesViewController();
            vc.Update();
        });

        $("#btnDelete").click(function () {
            var vc = new MoviesViewController();
            vc.Delete();
        });
    }

    this.LoadTable = function () {
        var ca = new ControlActions();
        var service = this.APIEndpoint + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*
         {
            "title": "CR7 la pelicula Solo En cines",
            "description": "Pelicula de Cristiano Ronaldo",
            "releaseDate": "2025-06-12T19:14:51.51",
            "genre": "Biografia de una per",
            "director": "CR7",
            "id": 2,
            "created": "2025-06-13T01:14:53.243",
            "updated": "0001-01-01T00:00:00"
         }

         <tr>
                        <th>Id</th>
						<th>Title</th>
						<th>Description</th>
						<th>ReleaseDate</th>
						<th>Genre</th>
						<th>Director</th>
                    </tr>
        */

        var columns = [];
        columns[0] = { 'data': 'id' };
        columns[1] = { 'data': 'title' };
        columns[2] = { 'data': 'description' };
        columns[3] = { 'data': 'releaseDate' };
        columns[4] = { 'data': 'genre' };
        columns[5] = { 'data': 'director' };

        $("#tblMovies").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns,
        });

        $("#tblMovies tbody").on("click",
            "tr",
            function () {
                //Extraemos la fila
                var row = $(this).closest("tr");

                //Extraemos el dto
                //Esto nos devuelve el JSON de la fila seleccionada por el usuario
                //Segun la data devuelta por el API
                var movieDto = $("#tblMovies").DataTable().row(row).data();

                //Binding con el form
                $("#txtId").val(movieDto.id);
                $("#txtTitle").val(movieDto.title);
                $("#txtDescription").val(movieDto.description);
                $("#txtGenre").val(movieDto.genre);
                $("#txtDirector").val(movieDto.director);

                //Fecha tiene un formato
                var onlyDate = movieDto.releaseDate.split("T");
                $("#txtReleaseDate").val(onlyDate[0]);

            });
    }

    this.Create = function() {
        var movieDto = {}

        movieDto.id = 0;
        movieDto.created = "2025-01-01";
        movieDto.updated = "2025-01-01";

        movieDto.title = $("#txtTitle").val();
        movieDto.description = $("#txtDescription").val();
        movieDto.releaseDate = $("#txtReleaseDate").val();
        movieDto.genre = $("#txtGenre").val();
        movieDto.director = $("#txtDirector").val();

        var ca = new ControlActions();
        var urlService = this.APIEndpoint + "/Create";

        ca.PostToAPI(urlService,
            movieDto,
            function () {
                $("#tblMovies").DataTable().ajax.reload();
        });
    }

    this.Update = function() {
        var movieDto = {}

        movieDto.id = $("#txtId").val();
        movieDto.created = "2025-01-01";
        movieDto.updated = "2025-01-01";

        movieDto.title = $("#txtTitle").val();
        movieDto.description = $("#txtDescription").val();
        movieDto.releaseDate = $("#txtReleaseDate").val();
        movieDto.genre = $("#txtGenre").val();
        movieDto.director = $("#txtDirector").val();

        var ca = new ControlActions();
        var urlService = this.APIEndpoint + "/Update";

        ca.PutToAPI(urlService,
            movieDto,
            function() {
                $("#tblMovies").DataTable().ajax.reload();
            });
    }

    this.Delete = function() {
        var movieDto = {}

        movieDto.id = $("#txtId").val();
        movieDto.created = "2025-01-01";
        movieDto.updated = "2025-01-01";

        movieDto.title = $("#txtTitle").val();
        movieDto.description = $("#txtDescription").val();
        movieDto.releaseDate = $("#txtReleaseDate").val();
        movieDto.genre = $("#txtGenre").val();
        movieDto.director = $("#txtDirector").val();

        var ca = new ControlActions();
        var urlService = this.APIEndpoint + "/Delete";

        ca.DeleteToAPI(urlService,
            movieDto,
            function() {
                $("#tblMovies").DataTable().ajax.reload();
            });
    }
}

$(document).ready(function () {
    var mc = new MoviesViewController();
    mc.InitView();
})