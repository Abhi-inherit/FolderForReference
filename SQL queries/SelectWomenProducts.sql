USE [Buyit]
GO
/****** Object:  StoredProcedure [dbo].[SelectWomenProducts]    Script Date: 10/29/2017 13:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SelectWomenProducts]
 As
 begin
  select * from ProductView where Category_Name = 'Women''s wear';
  end