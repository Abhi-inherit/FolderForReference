USE [FirstMCV_PartialView]
GO
/****** Object:  Table [dbo].[tbl_Place]    Script Date: 09/14/2017 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Place](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlaceName] [varchar](50) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_tbl_Place] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_People]    Script Date: 09/14/2017 11:29:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[DateOfBirth] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[Phone] [varchar](50) NULL,
	[Image] [varchar](50) NULL,
	[Place] [int] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_tbl_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_tbl_People_tbl_Place]    Script Date: 09/14/2017 11:29:50 ******/
ALTER TABLE [dbo].[tbl_People]  WITH CHECK ADD  CONSTRAINT [FK_tbl_People_tbl_Place] FOREIGN KEY([Place])
REFERENCES [dbo].[tbl_Place] ([Id])
GO
ALTER TABLE [dbo].[tbl_People] CHECK CONSTRAINT [FK_tbl_People_tbl_Place]
GO
