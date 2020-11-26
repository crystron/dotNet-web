Alter Proc TimKiem(@StrSearch Nvarchar(20),@SL int)
as
BEGIN
	IF ( @SL IS NULL )
		select *
		from Sach
		Where TenSach Like N'%'+@StrSearch+'%' Or MaSach Like N'%'+@StrSearch+'%' 
	Else
		select *
		from Sach
		Where ( TenSach Like N'%'+@StrSearch+'%' AND SL > @SL ) OR  ( MaSach Like N'%'+@StrSearch+'%' AND SL > @SL AND SL > @SL)
END
