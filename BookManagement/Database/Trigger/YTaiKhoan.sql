IF EXISTS (SELECT TOP 1 1 FROM DBO.SYSOBJECTS WITH(NOLOCK) WHERE ID = OBJECT_ID(N'[DBO].[YTaiKhoan]') AND OBJECTPROPERTY(ID, N'IsTrigger') = 1)
DROP TRIGGER [DBO].[YAccount]
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE TRIGGER [dbo].[YAccount] ON TAIKHOAN 
 FOR INSERT,UPDATE,DELETE
 AS
 SET NOCOUNT ON
 
	IF EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)-- Trigger them
	BEGIN 
			SELECT * 
			INTO #INSERTED
			FROM INSERTED
				
			SELECT * 
			INTO #DELETED
			FROM DELETED 
												
			CREATE TABLE #YAcount (FieldName VARCHAR(50), FieldDes NVARCHAR(250), OldValues NVARCHAR(500), NewValues NVARCHAR(500))
								
			DECLARE @FieldName VARCHAR(50),@FieldDes NVARCHAR(250), @SQL NVARCHAR(4000) = ''
					
			DECLARE cur  CURSOR FAST_FORWARD READ_ONLY FOR
							
			SELECT FieldName, FieldDes FROM WACCOUNT WHERE [Transaction] = N'Tài khoản'

			OPEN cur
			FETCH NEXT FROM cur INTO @FieldName, @FieldDes
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SELECT @SQL = N'
				INSERT INTO	#YAcount (FieldName, FieldDes, OldValues, NewValues)
				SELECT		'''+@FieldName+N''', N'''+@FieldDes+''', T1.'+@FieldName+', T.'+@FieldName+'
				FROM 		#INSERTED T
				INNER JOIN	#DELETED T1
					ON		T.UserID = T1.UserID
				WHERE T.'+@FieldName+' <> T1.'+@FieldName+'
				' 
				--PRINT @SQL
				EXEC (@SQL)
								
			FETCH FROM cur INTO  @FieldName, @FieldDes
			END	
							
			CLOSE cur
			DEALLOCATE cur 
							 
		SELECT	@SQL = ''
		SELECT	@SQL = @SQL+ FieldDes + ': ' + CASE WHEN ISNULL(OldValues,'') = '' THEN N'Trống' ELSE N'Từ: '+ OldValues END  + N' thành ' + NewValues + '; '
		FROM	#YAcount
		
		IF @SQL <> ''
		BEGIN				
			INSERT INTO SaveHistory (AuditDate, AuditCode, UserID, EventID, [Description], IP, AuditItemID)
			SELECT	GETDATE(), 'Form_Account', 'ADMIN' , 'EDIT', @SQL, '', UserID
			FROM	INSERTED
		END
		DROP TABLE #YAcount
		DROP TABLE #DELETED
		DROP TABLE #INSERTED
			
			--SELECT SaveHistory, D17T1010
	END
	ELSE IF EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS (SELECT * FROM DELETED)-- Trigger Them
	BEGIN
		INSERT INTO SaveHistory (AuditDate, AuditCode, UserID, EventID, [Description], IP, AuditItemID)
		SELECT GETDATE(), 'Form_Account', 'ADMIN', 'NEW', N'Tài khoản: '+UserName,'', UserID FROM INSERTED
		INSERT INTO AccountDetails(UserID)
		SELECT UserID FROM INSERTED
	END	
	ELSE IF EXISTS (SELECT * FROM DELETED) AND NOT EXISTS (SELECT * FROM INSERTED)	-- Trigger DELETE
	BEGIN				
		INSERT INTO SaveHistory (AuditDate, AuditCode, UserID, EventID, [Description], IP, AuditItemID)
		SELECT GETDATE(), 'Form_Account', 'ADMIN', 'DELETE',  N'Tài khoản: '+UserName, '', UserID FROM DELETED
	END