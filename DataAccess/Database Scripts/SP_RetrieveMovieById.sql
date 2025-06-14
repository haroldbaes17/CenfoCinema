CREATE PROCEDURE RET_MOVIEBYID_PR
	@P_Id int
AS
BEGIN
    SELECT Id, Created, Updated, Title, Description, ReleaseDate, Genre, Director
	FROM TBL_Movie
	WHERE Id = @P_Id;
END
GO