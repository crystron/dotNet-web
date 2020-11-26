IF EXISTS (SELECT TOP 1 1 FROM DBO.SYSOBJECTS WITH(NOLOCK) WHERE ID = OBJECT_ID(N'[DBO].[YTaiKhoan]') AND OBJECTPROPERTY(ID, N'IsTrigger') = 1)
DROP TRIGGER [DBO].[YTaiKhoan]
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
/* drop trigger ytaikhoan   */
CREATE TRIGGER [dbo].[YTaiKhoan] ON TaiKhoan
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
												
			CREATE TABLE #YTaiKhoan (FieldName VARCHAR(50), FieldDes NVARCHAR(250), OldValues NVARCHAR(500), NewValues NVARCHAR(500))
								
			DECLARE @FieldName VARCHAR(50),@FieldDes NVARCHAR(250), @SQL NVARCHAR(4000) = ''
					
			DECLARE cur  CURSOR FAST_FORWARD READ_ONLY FOR
							
			SELECT FieldName, FieldDes FROM VTaiKhoan WHERE [Transaction] = N'Tài khoản'

			OPEN cur
			FETCH NEXT FROM cur INTO @FieldName, @FieldDes
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SELECT @SQL = N'
				INSERT INTO	#YTaiKhoan (FieldName, FieldDes, OldValues, NewValues)
				SELECT		'''+@FieldName+N''', N'''+@FieldDes+''', T1.'+@FieldName+', T.'+@FieldName+'
				FROM 		#INSERTED T
				INNER JOIN	#DELETED T1
					ON		T.MaTK = T1.MaTK
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
		FROM	#YTaiKhoan
		
		IF @SQL <> ''
		BEGIN				
			INSERT INTO SaveHistory (AuditDate, AuditCode, EventID, [Description], AuditItemID)
			SELECT	GETDATE(), 'Form_Account', 'EDIT', @SQL, MaTK
			FROM	INSERTED
		END
		DROP TABLE #YTaiKhoan
		DROP TABLE #DELETED
		DROP TABLE #INSERTED
			
			--SELECT SaveHistory, D17T1010
	END
	ELSE IF EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS (SELECT * FROM DELETED)-- Trigger Them
	BEGIN
		DECLARE @MATK VARCHAR(20)
		Set @MATK = FORMAT((NEXT VALUE FOR SeTK),'TK0000000#')
		Update TaiKhoan
		Set MaTK = @MATK
		From inserted T1 join TaiKhoan t2 on t1.MaTK = t2.MaTK
		---------------------------------------------------------------------------------
		INSERT INTO SaveHistory (AuditDate, AuditCode, EventID, [Description], AuditItemID)
		SELECT GETDATE(), 'Form_Account', 'NEW', N'Tài khoản: '+TenTK, @MaTK FROM inserted
		---------------------------------------------------------------------------------
		INSERT INTO ChiTietTK(MaTK, TenTK, TenHienThi, MatKhau, Email, Quyen)
		SELECT @MaTK, TenTK, TenHienThi, MatKhau, Email, Quyen
		From inserted	
		

	END	
	ELSE IF EXISTS (SELECT * FROM DELETED) AND NOT EXISTS (SELECT * FROM INSERTED)	-- Trigger DELETE
	BEGIN				
		INSERT INTO SaveHistory (AuditDate, AuditCode, EventID, [Description], AuditItemID)
		SELECT GETDATE(), 'Form_Account', 'DELETE',  N'Tài khoản: ' +TenTK , MaTK FROM DELETED
	END