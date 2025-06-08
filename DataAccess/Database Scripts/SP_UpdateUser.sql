--SP para actualizar un User.
CREATE PROCEDURE UPD_USER_PR
	@P_Id int,
	@P_UserCode nvarchar(30),
	@P_Name nvarchar(50),
	@P_Email nvarchar(50),
	@P_Password nvarchar(50),
	@P_BirthDate datetime,
	@P_Status nvarchar(10)

AS
BEGIN
   UPDATE TBL_User 
   SET Updated = GETDATE(), UserCode = @P_UserCode, Name = @P_Name, Email = @P_Email, Password = @P_Password,
   BirthDate = @P_BirthDate, Status = @P_Status
   WHERE Id = @P_Id;
END
GO
