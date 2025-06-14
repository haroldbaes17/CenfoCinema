CREATE PROCEDURE RET_USERBYID_PR 
	@P_Id int

AS
BEGIN
    SELECT Id, Created, Updated,UserCode, Name, Email, Password, BirthDate, Status
	FROM TBL_User 
	WHERE Id = @P_Id;
END
GO
