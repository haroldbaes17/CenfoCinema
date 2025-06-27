function MoviesViewController() {
    this.ViewName = "Movies";
    this.APIEndpoint = "Movie";

    this.InitView = function () {
        console.log("Movies init view --> ok");
        this.LoadTable();
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
            "columns":columns,
        })
    }
}

$(document).ready(function () {
    var mc = new MoviesViewController();
    mc.InitView();
})