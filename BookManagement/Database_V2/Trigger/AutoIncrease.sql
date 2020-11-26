CREATE TRIGGER YKhachHang On KhachHang
FOR INSERT 
AS
	DECLARE @MAKH VARCHAR(20)
	Set @MAKH = FORMAT((NEXT VALUE FOR SeKH),'KH00#')
	UPDATE KhachHang
	Set MaKH = @MAKH
	FRom inserted t1 join KhachHang T2 ON T1.MaKH = T2.MaKH

CREATE TRIGGER YGioHang On GioHang
FOR INSERT 
AS
	DECLARE @MAGH VARCHAR(20)
	Set @MAGH = FORMAT((NEXT VALUE FOR SeGH),'GH00#')
	UPDATE GioHang
	Set MaGH = @MAGH
	FRom inserted t1 join GioHang T2 ON T1.MaGH = T2.MaGH


