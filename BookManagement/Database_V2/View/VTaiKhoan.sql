IF EXISTS (SELECT TOP 1 1 FROM DBO.SYSOBJECTS WITH(NOLOCK) WHERE ID = OBJECT_ID(N'[DBO].[VTaiKhoan]') AND OBJECTPROPERTY(ID, N'IsView') = 1)
DROP VIEW [DBO].[VTaiKhoan]
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




-- <Summary>
----View danh sach cac truong de Duyet cursor ghi nhan lich su tac dong 
-- <Param>
---- 
-- <Return>
---- 
-- <Reference>
---- 
-- <History>
---- Create on 16/03/2019 by 
---- 
---- Modified on 16/03/2019 by 
-- <Example>
---- select * from WACCOUNT
CREATE VIEW VTaiKhoan
as
	SELECT  'TenTK' AS FieldName, N'Tên tài khoản' FieldDes , 1 AS OrderNo, N'Tài khoản' AS [Transaction]
	UNION ALL
	SELECT  'TenHienThi' AS FieldName, N'Tên hiển thị' FieldDes , 2 AS OrderNo, N'Tài khoản' AS [Transaction]
	UNION ALL
	SELECT  'MatKhau' AS FieldName, N'Mật khẩu' FieldDes , 1 AS OrderNo, N'Tài khoản' AS [Transaction]
	UNION ALL
	SELECT  'Quyen' AS FieldName, N'Phân quyền' FieldDes , 2 AS OrderNo, N'Tài khoản' AS [Transaction]
	UNION ALL
	SELECT  'Email' AS FieldName, N'Email' FieldDes , 2 AS OrderNo, N'Tài khoản' AS [Transaction]
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
