IF EXISTS (SELECT * FROM DBO.SYSOBJECTS WHERE ID = OBJECT_ID(N'[DBO].[Login]') AND OBJECTPROPERTY(ID, N'IsProcedure') = 1)
DROP PROCEDURE [DBO].[Login]
GO
Create Procedure Login
	@UserName Nvarchar(100),
	@Password Nvarchar(100)
AS
					SELECT  *
					FROM TAIKHOAN
					Where TENTK = @UserName And MK = @Password
-- EXEC Login 'Phoenix','12345'
