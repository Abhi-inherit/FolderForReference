USE [Buyit]
GO
/****** Object:  StoredProcedure [dbo].[BrandInsert]    Script Date: 10/29/2017 13:20:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BrandInsert]
(
	@Brand_Name as varchar(50)
	)
AS
BEGIN
Begin transaction
declare @result as varchar(50), @exist as int
	set @exist = (select count (*) from Brand where Brand_Name=@Brand_Name)
	if(@exist>0)
	begin
	set @result = 'Already Exist'
	end
	else
	begin
	insert into Brand(Brand_Name) values (@Brand_Name)
	if(@@ERROR>0)
	begin
	set @result = 'SQL error occured'
	rollback transaction
	end
else
	begin
	set @result='Success'
	end
end
commit transaction
select @result
end
