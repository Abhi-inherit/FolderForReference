USE [Buyit]
GO
/****** Object:  StoredProcedure [dbo].[BrandDelete]    Script Date: 10/29/2017 13:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[BrandDelete] 
(
	@Brand_ID int
)
as
begin
begin transaction
declare @result as varchar (50)
begin
Delete from Brand where Brand_ID = @Brand_ID;
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
