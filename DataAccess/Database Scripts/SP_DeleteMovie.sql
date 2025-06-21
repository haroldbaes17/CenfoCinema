--SP para eliminar Movie
CREATE PROCEDURE DEL_MOVIE_PR
    @P_Id int
AS
BEGIN
    DELETE  FROM TBL_Movie 
	WHERE Id = @P_Id;
END
GO