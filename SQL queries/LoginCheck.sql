USE [Buyit]
GO
/****** Object:  StoredProcedure [dbo].[LoginCheck]    Script Date: 10/29/2017 13:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[LoginCheck]
	(
	@Email as varchar(50),
	@Password as Varchar(50)
	)
AS
BEGIN
Begin transaction
declare @result as varchar(50), @exist as int
	set @exist = (select count (*) from Admin where Email=@Email and Password=@Password)
	
	if(@exist>0)
	begin
	set @result = 'Exists'
	end
	
	if(@exist=0)
	begin
	set @result = 'Not Exist'
	end
	
	if(@@ERROR>0)
	begin
	set @result = 'SQL error occured'
	rollback transaction
	end
	commit transaction
	
	select @result
	end
