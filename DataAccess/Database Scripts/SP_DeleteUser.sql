--SP para eliminar User
CREATE PROCEDURE DEL_USER_PR
    @P_Id int
AS
BEGIN
    DELETE  FROM TBL_User 
	WHERE Id = @P_Id;
END
GO
