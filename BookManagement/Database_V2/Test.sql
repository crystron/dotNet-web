CREATE TRIGGER YKhachHang On KhachHang
FOR INSERT 
AS
	DECLARE @MAKH VARCHAR(20)
	Set @MAKH = FORMAT((NEXT VALUE FOR SeKH),'KH0000000#')
	Update KhachHang
	Set MaKH = @MAKH
	From inserted T1 join TaiKhoan t2 on T1.MaKH = T2.MaKH

