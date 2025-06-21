/****** Object:  StoredProcedure [dbo].[RET_USER_BY_EMAIL_PR]    Script Date: 21/6/2025 11:20:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RET_USER_BY_EMAIL_PR]
	@P_Email nvarchar(50)
AS
BEGIN
    SELECT Id, Created, Updated,UserCode, Name, Email, Password, BirthDate, Status
	FROM TBL_User 
	WHERE Email = @P_Email;
END
GO


