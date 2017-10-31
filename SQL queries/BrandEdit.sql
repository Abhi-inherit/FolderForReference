USE [Buyit]
GO
/****** Object:  StoredProcedure [dbo].[BrandEdit]    Script Date: 10/29/2017 13:20:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BrandEdit]
(
@Brand_ID int,
@Brand_name varchar(50)
)
as
begin
begin transaction
declare @result as varchar (50)
begin
update Brand set Brand_Name = @Brand_name where Brand_ID = @Brand_ID;

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
