--SP para Actualizar una Movie
CREATE PROCEDURE  UPD_MOVIE_PR(
	@P_Id int, 
	@P_Title nvarchar(75),
	@P_Description nvarchar(250),
	@P_Genre nvarchar(20),
	@P_Director nvarchar(50)
)
AS
BEGIN
	UPDATE TBL_Movie
	SET Updated = GETDATE(), Title = @P_Title, Description = @P_Description,
	Genre = @P_Genre, Director = @P_Director 
	WHERE Id = @P_Id;
END
GO