alter proc search
(
	@StrSearch varchar(100),
	@Table varchar(10)
)
as
	declare @sql  nvarchar(max) = '' , @sql01 nvarchar(max) = ''
	set @sql01 = 'Ma' + @Table
	set @sql = '
	Select *
	From '+@Table+'
	Where '+@sql01+'  LIKE N''%' +@StrSearch+ '%''
	'
	print @sql

exec search sach, Sach
	--Select MaSach, TenSach, GiaTien, SL
	--From Sach
	--Where MaSach  LIKE N'%sach%'