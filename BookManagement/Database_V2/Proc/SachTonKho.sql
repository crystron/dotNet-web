Select *
From Sach T1 Join ChiTietGioHang T2 On T1.MaSach = T2.MaSach
Order By T1.MaSach

Select *
From GioHang T1 LEFT JOIN ChiTietGioHang T2 On T1.MaGH = T2.MaGH
Where MONTH(GETDATE()) - MONTH(NgayDatHang) > 6 OR T2.MaSach NOT IN (Select MaSach From Sach)

Create Proc PTonKho
As
Select *
From Sach T1 
Where (T1.MaSach NOT IN (Select MaSach From ChiTietGioHang )) OR T1.MaSach IN (Select T1.MaSach From ChiTietGioHang T1 Join GioHang T2 On T1.MaGH = T2.MaGH
																				Where Month(GETDATE()) - MONTH(T2.NgayDatHang) > 6)
Exec PTonKho