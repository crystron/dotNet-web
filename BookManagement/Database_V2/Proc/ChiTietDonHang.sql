Alter Proc ChiTietDH (@MaGH VARCHAR(10))
As
	Select T1.MaGH, T4.TenKh, T3.TenSach, T2.SoLuong, T3.GiaTien
	From GioHang T1 LEFT JOIN ChiTietGioHang T2 On T1.MaGH = T2.MaGH JOIN Sach T3 On T2.MaSach = T3.MaSach Join KhachHang T4 On T1.MaKH = T4.MaKH
	Where T1.MaGH = @MaGH

Exec ChiTietDH 'GH00000005'


