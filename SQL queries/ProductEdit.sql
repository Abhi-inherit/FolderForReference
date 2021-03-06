USE [Buyit]
GO
/****** Object:  StoredProcedure [dbo].[ProductEdit]    Script Date: 10/29/2017 13:22:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ProductEdit]
(
	@Product_ID as int,
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
as
begin
begin transaction
declare @result as varchar (50)
begin
update Product set 
Product_Name = @Product_Name,
FK_Category_ID = @FK_Category_ID,
FK_First_Category_ID = @FK_First_Category_ID, 
FK_Second_Category_ID = @FK_Second_Category_ID,
FK_Third_Category_ID = @FK_Third_Category_ID,
Price = @Price,
FK_Brand_ID = @FK_Brand_ID,
Description = @Description,
ImagePath = @ImagePath,
Qty = @Qty
where Product_ID = @Product_ID;

if (@@ERROR>0)
begin
set @result = 'SQL error happened'
end
else
begin
set @result = 'Success'
end
commit transaction
select @result
end
end
