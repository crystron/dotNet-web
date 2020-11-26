CREATE TRIGGER UpdateSL On ChiTietGioHang
FOR INSERT 
AS
	BEGIN
	DECLARE @SLTON INT, @SLXUAT INT, @SL INT
	SELECT @SLTON = T2.SL, @SLXUAT = T1.SoLuong FROM inserted T1 JOIN Sach T2 ON T1.masach = T2.masach
	
		UPDATE T1
		SET sl = @SLTON - @SLXUAT
		FROM Sach T1 JOIN inserted T2 ON T1.MaSach = T2.MaSach 
		WHERE T1.MaSach IN (SELECT MaSach FROM inserted)
	END


INSERT INTO cthd(mahd,masach,SL) VALUES(1,1,2)
INSERT INTO cthd(mahd,masach,SL) VALUES(1,2,2)
INSERT INTO cthd(mahd,masach,SL) VALUES(1,4,1)

DELETE Sach
Where MaSach = 'SACH019'
