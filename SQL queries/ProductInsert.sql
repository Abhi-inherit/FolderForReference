USE [Buyit]
GO
/****** Object:  StoredProcedure [dbo].[ProductInsert]    Script Date: 10/29/2017 13:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ProductInsert]
(
	@Product_Name as varchar(50),
	@FK_Category_ID as int,
	@FK_First_Category_ID as int,
	@FK_Second_Category_ID as int,
	@FK_Third_Category_ID as int,
	@Price as int,
	@FK_Brand_ID as int,
	@Description as varchar(5000),
	@ImagePath as nvarchar(max),
	@Qty as int
	)
AS
BEGIN
Begin transaction
declare @result as varchar(50), @exist as int
	set @exist = (select count (*) from Product where Product_Name=@Product_Name)
	if(@exist>0)
	begin
	set @result = 'Already Exist'
	end
	else
	begin
	insert into Product(Product_Name,FK_Category_ID,FK_First_Category_ID,FK_Second_Category_ID,FK_Third_Category_ID,Price,FK_Brand_ID,Description,ImagePath,Qty) values (@Product_Name,@FK_Category_ID,@FK_First_Category_ID,@FK_Second_Category_ID,@FK_Third_Category_ID,@Price,@FK_Brand_ID,@Description,@ImagePath,@Qty)
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
