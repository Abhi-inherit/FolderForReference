USE [SellNbuy]
GO
/****** Object:  StoredProcedure [dbo].[Pro_Motor_Insert]    Script Date: 10/29/2017 13:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Pro_Motor_Insert]
(
	@fk_cat_id as int,
	@title as varchar(100),
	@company as varchar(100),
	@photo as varchar(100),
	@km as int,
	@year as int,
	@body as varchar(100),
	@engine as varchar(100),
	@fuel as varchar(100),
	@hp as varchar(100),
	@phoneno as varchar(100),
	@price as varchar(100),
	@description as varchar(100),
	@location as varchar(100),
	@checkbox as varchar(500)
)
AS
BEGIN
Begin transaction
declare @result as varchar(50)
	begin
	insert into pro_motor(fk_cat_id,title,company,photo,km,year,body,engine,fuel,hp,phoneno,price,description,location,checkbox) values (@fk_cat_id,@title,@company,@photo,@km,@year,@body,@engine,@fuel,@hp,@phoneno,@price,@description,@location,@checkbox)
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
