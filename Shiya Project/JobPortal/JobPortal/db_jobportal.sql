USE [Db_JobPortal]
GO
/****** Object:  Table [dbo].[tbl_Location]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Location](
	[LocationId] [bigint] NOT NULL,
	[LocationName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_Location] ([LocationId], [LocationName]) VALUES (1, N'kerala')
/****** Object:  Table [dbo].[tbl_Jobs]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Jobs](
	[Job_Id] [numeric](18, 0) NOT NULL,
	[Job_EmployerId] [bigint] NULL,
	[Job_CategoryId] [bigint] NOT NULL,
	[Job_LocationId] [bigint] NOT NULL,
	[Job_ExpLevelId] [bigint] NOT NULL,
	[Job_Title] [nvarchar](50) NULL,
	[Job_Designation] [nvarchar](50) NULL,
	[Job_Description] [nvarchar](max) NULL,
	[Job_DateTime] [datetime] NULL,
	[Job_Status] [bit] NULL,
 CONSTRAINT [PK_tbl_Jobs] PRIMARY KEY CLUSTERED 
(
	[Job_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ExperienceLevel]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ExperienceLevel](
	[ExperienceId] [bigint] NOT NULL,
	[ExperienceLevel] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_ExperienceLevel] PRIMARY KEY CLUSTERED 
(
	[ExperienceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_ExperienceLevel] ([ExperienceId], [ExperienceLevel]) VALUES (1, N'Fresher')
/****** Object:  Table [dbo].[tbl_EmployerManageCandidateProfile]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EmployerManageCandidateProfile](
	[Cand_Id] [numeric](18, 0) NOT NULL,
	[Job_Id] [numeric](18, 0) NULL,
	[ViewedDateTime] [datetime] NULL,
	[IsShortlisted] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Category](
	[CategoryId] [bigint] NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_Category] ([CategoryId], [CategoryName]) VALUES (1, N'Category1')
/****** Object:  Table [dbo].[tbl_CandidateAppliedJobs]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CandidateAppliedJobs](
	[Cand_Id] [numeric](18, 0) NOT NULL,
	[Job_Id] [numeric](18, 0) NOT NULL,
	[JobAppliedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetViewProfile]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetViewProfile]
 @Cand_Id numeric(18,0)
,@Job_Id numeric(18,0)
,@IsShortlisted bit


AS
BEGIN
	Declare @Query varchar(50)='where';
	if(@Cand_Id!=0)
		set @Query=@Query+'Cand_Id='+@Cand_Id+'';
	if(@Job_Id!=0)
		set @Query=@Query+'Job_Id='+@Job_Id+'';
	if(@IsShortlisted!=0)
		set @Query=@Query+'IsShortlisted='+CAST(@IsShortlisted AS VARCHAR(50))+'';
		
	set @Query='SELECT * FROM vw_ViewProfileHistory '+@Query+'';
	exec(@Query);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLocation]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetLocation]
 @LocationId bigint
,@LocationName nvarchar(50)


AS
BEGIN
	Declare @Query varchar(50)='where';
	
	
	if(@LocationId!=0)
		set @Query=@Query+'LocationId='+@LocationId+'';
	if(@LocationName!='')
		set @Query=@Query+'LocationName ='+@LocationName+'';
	
	set @Query='SELECT * FROM tbl_Location '+@Query+'';
	exec(@Query);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetJobs]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetJobs]
 @Cand_Id numeric
,@Emp_Id bigint
,@Job_CategoryId bigint
,@Job_LocationId bigint
,@Job_ExpLevelId bigint
,@Job_Title nvarchar(50)
,@Job_Description nvarchar(50)
,@Job_Status bit

AS
BEGIN
	Declare @Query varchar(50)='where';
	
	if(@Cand_Id!=0)
		set @Query=@Query+'Cand_Id='+@Cand_Id+'';
	if(@Job_CategoryId!=0)
		set @Query=@Query+'Job_CategoryId='+@Job_CategoryId+'';
	if(@Job_LocationId!=0)
		set @Query=@Query+'Job_LocationId='+@Job_LocationId+'';
	if(@Job_ExpLevelId!=0)
		set @Query=@Query+'Job_ExpLevelId='+@Job_ExpLevelId+'';
	if(@Job_Title!='')
		set @Query='Job_Title='+@Job_Title+'';
	if(@Job_Description!='')
		set @Query=@Query+'Job_Description LIKE "%'+@Job_Description+'%"';
	if(@Job_Status!=0)
		set @Query=@Query+'Job_Status='+CAST(@Job_Status AS VARCHAR(50))+'';
		
	set @Query='SELECT * FROM vw_JobDetails '+@Query+'';
	exec(@Query);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetExperienceLevel]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetExperienceLevel]
 @ExperienceId bigint
,@ExperienceLevel nvarchar(50)


AS
BEGIN
	Declare @Query varchar(50)='where';
	
	
	if(@ExperienceId!=0)
		set @Query=@Query+'ExperienceId='+@ExperienceId+'';
	if(@ExperienceLevel!='')
		set @Query=@Query+'ExperienceLevel ='+@ExperienceLevel+'';
	
	set @Query='SELECT * FROM tbl_ExperienceLevel '+@Query+'';
	exec(@Query);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployer]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetEmployer]
 @Emp_Id bigint
,@Emp_Name nvarchar(50)
,@Emp_Status bit

AS
BEGIN
	Declare @Query varchar(50)='where';
	
	if(@Emp_Id!=0)
		set @Query=@Query+'Emp_Id='+@Emp_Id+'';
	if(@Emp_Name!='')
		set @Query='Emp_Name='+@Emp_Name+'';
	if(@Emp_Status!=0)
		set @Query=@Query+'Emp_Status='+CAST(@Emp_Status AS VARCHAR(50))+'';
		
	set @Query='SELECT * FROM tbl_Employer '+@Query+'';
	exec(@Query);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategory]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetCategory]
 @CategoryId bigint
,@CategoryName nvarchar(50)


AS
BEGIN
	Declare @Query varchar(50)='where';
	
	
	if(@CategoryId!=0)
		set @Query=@Query+'CategoryId='+@CategoryId+'';
	if(@CategoryName!='')
		set @Query=@Query+'CategoryName ='+@CategoryName+'';
	
	set @Query='SELECT * FROM tbl_Category '+@Query+'';
	exec(@Query);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCandidateAppliedJobs]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetCandidateAppliedJobs]
 @Cand_Id numeric(18,0)
,@Job_Id numeric(18,0)


AS
BEGIN
	Declare @Query varchar(50)='where';
	if(@Cand_Id!=0)
		set @Query=@Query+'Cand_Id='+@Cand_Id+'';
	if(@Job_Id!=0)
		set @Query=@Query+'Job_Id='+@Job_Id+'';
	
		
	set @Query='SELECT * FROM vw_JobDetails '+@Query+'';
	exec(@Query);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Location]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Delete_Location]
 @LocationId numeric(18,0)
AS
BEGIN
	Delete From tbl_Location where LocationId=@LocationId
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Job]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Delete_Job]
 @Job_Id numeric(18,0)
AS
BEGIN
	Delete From tbl_Jobs where Job_Id=@Job_Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_ExperienceLevel]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Delete_ExperienceLevel]
 @ExperienceId numeric(18,0)
AS
BEGIN
	Delete From tbl_ExperienceLevel where ExperienceId=@ExperienceId
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_ViewProfileHistory]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Insert_ViewProfileHistory]
 @Cand_Id numeric(18,0)
,@Job_Id numeric(18,0)
,@ViewedDateTime datetime
,@IsShortlisted bit
AS
BEGIN
	Insert into tbl_EmployerManageCandidateProfile values(@Cand_Id,@Job_Id,@ViewedDateTime,@IsShortlisted);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_CandidateAppliedJobs]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Insert_CandidateAppliedJobs]
 @Cand_Id numeric(18,0)
,@Job_Id numeric(18,0)
,@JobAppliedDateTime datetime
AS
BEGIN
	Insert into tbl_CandidateAppliedJobs values(@Cand_Id,@Job_Id,@JobAppliedDateTime);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Category]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Delete_Category]
 @CategoryId numeric(18,0)
AS
BEGIN
	Delete From tbl_Category where CategoryId=@CategoryId
	
END
GO
/****** Object:  Table [dbo].[tbl_Candidate]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Candidate](
	[Cand_Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Cand_CategoryId] [bigint] NOT NULL,
	[Cand_LocationId] [bigint] NOT NULL,
	[Cand_ExpLevelId] [bigint] NOT NULL,
	[Cand_Name] [nvarchar](50) NULL,
	[Cand_UserName] [nvarchar](50) NULL,
	[Cand_Password] [nvarchar](50) NULL,
	[Cand_EmailId] [nvarchar](50) NULL,
	[Cand_MobileNumber] [nvarchar](50) NULL,
	[Cand_Address] [nvarchar](50) NULL,
	[Cand_HighestQualification] [nvarchar](50) NULL,
	[Cand_SkillDescription] [nvarchar](max) NULL,
	[Cand_Resume] [nvarchar](50) NULL,
	[Cand_DateTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_Candidate] PRIMARY KEY CLUSTERED 
(
	[Cand_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Candidate] ON
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(2 AS Numeric(18, 0)), 1, 1, 1, N'dsfdg', N'fghf', N'ghj', N'ghj', N'ghj', N'ghj', N'ghj', N'ghj', N'ghj', CAST(0x00009FC300D60704 AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(3 AS Numeric(18, 0)), 1, 1, 1, N'hjgh', N'hjk', N'hjk', N'hjl', N'jkl', N'jkl', N'hjkl', N'jhkl', N'jlk', CAST(0x00009FC300D60704 AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(5 AS Numeric(18, 0)), 1, 1, 1, N'cvbcvb', N'cbvcvb', N'cvbcvb', N'cvbcvb', N'cvbcvb', N'cvbcvb', N'cvbcvb', N'cbvcvb', N'Read me.txt', CAST(0x0000A7DF00DFD9C5 AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(6 AS Numeric(18, 0)), 1, 1, 1, N'ghjghj', N'fgfgj', N'fgjhghj', N'ghjghj', N'ghjghj', N'ghjghj', N'fgjhghj', N'gfjhghj', N'', CAST(0x0000A7DF00F48FD5 AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(7 AS Numeric(18, 0)), 0, 0, 0, N'ghghj', N'gghj', N'ghjghj', N'ghjghj', N'ghjghj', N'ghjghj', N'ghjghj', N'ghjghj', N'', CAST(0x0000A7DF00FD8AFF AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(8 AS Numeric(18, 0)), 0, 0, 0, N'vcxv', N'cvxcv', N'xcvv', N'xcvbvb', N'bxc', N'cvb', N'cvb', N'vcb', N'', CAST(0x0000A7DF00FDE996 AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(9 AS Numeric(18, 0)), 0, 0, 0, N'fgfgh', N'gfgh', N'fghfg', N'fghfhg', N'fghfh', N'fhfgh', N'fghfgh', N'fghfg', N'D:\ShiyaProjects\JobPortal\JobPortal\Resume\Read m', CAST(0x0000A7DF00FEAB01 AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(10 AS Numeric(18, 0)), 0, 0, 0, N'vbn', N'vbvn', N'vbnvbn', N'vbn', N'vbnvbn', N'vbnvbn', N'vbnvbn', N'vbnvbn', N'', CAST(0x0000A7DF010023FD AS DateTime))
INSERT [dbo].[tbl_Candidate] ([Cand_Id], [Cand_CategoryId], [Cand_LocationId], [Cand_ExpLevelId], [Cand_Name], [Cand_UserName], [Cand_Password], [Cand_EmailId], [Cand_MobileNumber], [Cand_Address], [Cand_HighestQualification], [Cand_SkillDescription], [Cand_Resume], [Cand_DateTime]) VALUES (CAST(11 AS Numeric(18, 0)), 1, 1, 1, N'vbnvbn', N'bvvbn', N'vbvnb', N'vbnvbn', N'vbnvbn', N'vbnvbn', N'vbnvbn', N'vnvbn', N'D:\ShiyaProjects\JobPortal\JobPortal\Resume\Read m', CAST(0x0000A7DF0100DE66 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_Candidate] OFF
/****** Object:  StoredProcedure [dbo].[sp_ManageLocation]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ManageLocation]
 @LocationId bigInt
,@LocationName nvarchar(50)

AS
BEGIN

	if(@LocationId=0)
		begin
			Insert into tbl_Location(LocationId,LocationName) values(@LocationId,@LocationName);
		end
	else
		begin
			Update tbl_Location SET
			 LocationName =@LocationName
		   Where LocationId=@LocationId
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ManageJob]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ManageJob]
 @Job_Id numeric(18,0)
,@Job_EmployerId bigint
,@Job_CategoryId bigint
,@Job_LocationId bigint
,@Job_ExpLevelId bigint
,@Job_Title nvarchar(50)
,@Job_Designation nvarchar(50)
,@Job_Description nvarchar(max)
,@Job_DateTime datetime
,@Job_Status bit
AS
BEGIN

	if(@Job_Id=0)
		begin
			Insert into tbl_Jobs(Job_Id,Job_EmployerId,Job_CategoryId,Job_LocationId,Job_DateTime,Job_ExpLevelId,Job_Title,Job_Designation,Job_Description,Job_Status) values
									 (@Job_Id,@Job_EmployerId,@Job_CategoryId,@Job_LocationId,@Job_DateTime,@Job_ExpLevelId,@Job_Title,@Job_Designation,@Job_Description,@Job_Status);
		end
	else
		begin
			Update tbl_Jobs SET
			 Job_EmployerId =@Job_EmployerId
			,Job_CategoryId =@Job_CategoryId
			,Job_LocationId =@Job_LocationId
			,Job_DateTime =@Job_DateTime
			,Job_ExpLevelId =@Job_ExpLevelId
			,Job_Title =@Job_Title
			,Job_Designation =@Job_Designation
			,Job_Description =@Job_Description
		   Where Job_Id=@Job_Id
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ManageExperienceLevel]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ManageExperienceLevel]
 @ExperienceId bigInt
,@ExperienceLevel nvarchar(50)

AS
BEGIN

	if(@ExperienceId=0)
		begin
			Insert into tbl_ExperienceLevel(ExperienceId,ExperienceLevel) values(@ExperienceId,@ExperienceLevel);
		end
	else
		begin
			Update tbl_ExperienceLevel SET
			 ExperienceLevel =@ExperienceLevel
		   Where ExperienceId=@ExperienceId
		end
END
GO
/****** Object:  Table [dbo].[tbl_Employer]    Script Date: 08/30/2017 15:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employer](
	[Emp_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Emp_Name] [nvarchar](50) NULL,
	[Emp_Address] [nvarchar](max) NULL,
	[Emp_ContactPersonName] [nvarchar](50) NULL,
	[Emp_EmailId] [nvarchar](50) NULL,
	[Emp_MobileNumber] [nvarchar](50) NULL,
	[Emp_Place] [nvarchar](50) NULL,
	[Emp_LogoImage] [nvarchar](50) NULL,
	[Emp_DateTime] [datetime] NULL,
	[Emp_Status] [bit] NULL,
 CONSTRAINT [PK_tbl_Employer] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Employer] ON
INSERT [dbo].[tbl_Employer] ([Emp_Id], [Emp_Name], [Emp_Address], [Emp_ContactPersonName], [Emp_EmailId], [Emp_MobileNumber], [Emp_Place], [Emp_LogoImage], [Emp_DateTime], [Emp_Status]) VALUES (2, N'xcvxc', N'xcv', N'vcb', N'cvb', N'cvb', N'vb', N'cvb', CAST(0x00009FC300D60704 AS DateTime), 0)
INSERT [dbo].[tbl_Employer] ([Emp_Id], [Emp_Name], [Emp_Address], [Emp_ContactPersonName], [Emp_EmailId], [Emp_MobileNumber], [Emp_Place], [Emp_LogoImage], [Emp_DateTime], [Emp_Status]) VALUES (3, N'cxcv', N'fgh', N'fgjgj', N'ghj', N'ghj', N'ghj', N'ghj', CAST(0x00009FC300D60704 AS DateTime), 0)
INSERT [dbo].[tbl_Employer] ([Emp_Id], [Emp_Name], [Emp_Address], [Emp_ContactPersonName], [Emp_EmailId], [Emp_MobileNumber], [Emp_Place], [Emp_LogoImage], [Emp_DateTime], [Emp_Status]) VALUES (4, N'ghj', N'ghj', N'ghj', N'ghj', N'ghj', N'ghj', N'ghj', CAST(0x00009FC300D60704 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[tbl_Employer] OFF
/****** Object:  StoredProcedure [dbo].[sp_ManageCategory]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ManageCategory]
 @CategoryId bigInt
,@CategoryName nvarchar(50)

AS
BEGIN

	if(@CategoryId=0)
		begin
			Insert into tbl_Category(CategoryId,CategoryName) values(@CategoryId,@CategoryName);
		end
	else
		begin
			Update tbl_Category SET
			 CategoryName =@CategoryName
		   Where CategoryId=@CategoryId
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ManageCandidate]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ManageCandidate]
 @Cand_Id bigInt
,@Cand_CategoryId bigInt
,@Cand_LocationId bigInt
,@Cand_ExpLevelId bigInt
,@Cand_Name nvarchar(50)
,@Cand_UserName nvarchar(50)
,@Cand_Password nvarchar(50)
,@Cand_EmailId nvarchar(50)
,@Cand_MobileNumber nvarchar(50)
,@Cand_Address nvarchar(50)
,@Cand_HighestQualification nvarchar(50)
,@Cand_SkillDescription nvarchar(max)
,@Cand_Resume nvarchar(50)
AS
BEGIN

	if(@Cand_Id=0)
		begin
			Insert into tbl_Candidate(Cand_CategoryId,Cand_LocationId,Cand_ExpLevelId,Cand_Name,Cand_UserName,Cand_Password,Cand_EmailId,Cand_MobileNumber,Cand_Address,Cand_HighestQualification,Cand_SkillDescription,Cand_Resume,Cand_DateTime) values
									 (@Cand_CategoryId,@Cand_LocationId,@Cand_ExpLevelId,@Cand_Name,@Cand_UserName,@Cand_Password,@Cand_EmailId,@Cand_MobileNumber,@Cand_Address,@Cand_HighestQualification,@Cand_SkillDescription,@Cand_Resume,getdate());
		end
	else
		begin
			Update tbl_Candidate SET
			 Cand_CategoryId =@Cand_CategoryId
			,Cand_LocationId =@Cand_LocationId
			,Cand_ExpLevelId =@Cand_ExpLevelId
			,Cand_Name =@Cand_Name
			,Cand_UserName =@Cand_UserName
			,Cand_Password =@Cand_Password
			,Cand_EmailId =@Cand_EmailId
			,Cand_MobileNumber =@Cand_MobileNumber
			,Cand_Address =@Cand_Address
			,Cand_HighestQualification =@Cand_HighestQualification
			,Cand_SkillDescription =@Cand_SkillDescription
			,Cand_Resume =@Cand_Resume
			,Cand_DateTime =getdate()
		   Where Cand_Id=@Cand_Id
		end
END
GO
/****** Object:  View [dbo].[vw_ViewProfileHistory]    Script Date: 08/30/2017 15:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ViewProfileHistory]
AS
SELECT     dbo.tbl_Employer.Emp_Name, dbo.tbl_EmployerManageCandidateProfile.Cand_Id, dbo.tbl_EmployerManageCandidateProfile.Job_Id, 
                      dbo.tbl_EmployerManageCandidateProfile.ViewedDateTime, dbo.tbl_EmployerManageCandidateProfile.IsShortlisted, dbo.tbl_Jobs.Job_Title, 
                      dbo.tbl_Jobs.Job_Designation, dbo.tbl_Jobs.Job_Description
FROM         dbo.tbl_EmployerManageCandidateProfile INNER JOIN
                      dbo.tbl_Jobs ON dbo.tbl_EmployerManageCandidateProfile.Job_Id = dbo.tbl_Jobs.Job_Id INNER JOIN
                      dbo.tbl_Employer ON dbo.tbl_Jobs.Job_EmployerId = dbo.tbl_Employer.Emp_Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_EmployerManageCandidateProfile"
            Begin Extent = 
               Top = 77
               Left = 749
               Bottom = 196
               Right = 917
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_Employer"
            Begin Extent = 
               Top = 7
               Left = 226
               Bottom = 126
               Right = 439
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tbl_Jobs"
            Begin Extent = 
               Top = 104
               Left = 4
               Bottom = 223
               Right = 172
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ViewProfileHistory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ViewProfileHistory'
GO
/****** Object:  View [dbo].[vw_JobDetails]    Script Date: 08/30/2017 15:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_JobDetails]
AS
SELECT     dbo.tbl_Jobs.Job_EmployerId, dbo.tbl_Jobs.Job_CategoryId, dbo.tbl_Jobs.Job_LocationId, dbo.tbl_Jobs.Job_Id, dbo.tbl_Jobs.Job_ExpLevelId, dbo.tbl_Jobs.Job_Title, 
                      dbo.tbl_Jobs.Job_Designation, dbo.tbl_Jobs.Job_Description, dbo.tbl_Jobs.Job_DateTime, dbo.tbl_Jobs.Job_Status, dbo.tbl_Employer.Emp_Name, 
                      dbo.tbl_Candidate.Cand_Name, dbo.tbl_Candidate.Cand_ExpLevelId, dbo.tbl_Candidate.Cand_LocationId, dbo.tbl_Candidate.Cand_CategoryId, 
                      dbo.tbl_Candidate.Cand_Address, dbo.tbl_Candidate.Cand_HighestQualification, dbo.tbl_Candidate.Cand_SkillDescription, dbo.tbl_Candidate.Cand_Resume, 
                      dbo.tbl_CandidateAppliedJobs.Cand_Id
FROM         dbo.tbl_Jobs INNER JOIN
                      dbo.tbl_CandidateAppliedJobs ON dbo.tbl_Jobs.Job_Id = dbo.tbl_CandidateAppliedJobs.Job_Id INNER JOIN
                      dbo.tbl_Candidate ON dbo.tbl_CandidateAppliedJobs.Cand_Id = dbo.tbl_Candidate.Cand_Id INNER JOIN
                      dbo.tbl_Employer ON dbo.tbl_Jobs.Job_EmployerId = dbo.tbl_Employer.Emp_Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[65] 4[4] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_Jobs"
            Begin Extent = 
               Top = 13
               Left = 155
               Bottom = 132
               Right = 323
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_CandidateAppliedJobs"
            Begin Extent = 
               Top = 13
               Left = 356
               Bottom = 117
               Right = 542
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_Candidate"
            Begin Extent = 
               Top = 41
               Left = 641
               Bottom = 160
               Right = 856
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "tbl_Employer"
            Begin Extent = 
               Top = 150
               Left = 29
               Bottom = 269
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_JobDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_JobDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_JobDetails'
GO
/****** Object:  Trigger [tgr_AfterDeleteEmployer]    Script Date: 08/30/2017 15:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tgr_AfterDeleteEmployer] ON [dbo].[tbl_Employer]
AFTER DELETE
AS
DECLARE @Emp_Id bigint;

	SELECT @Emp_Id=d.Emp_Id FROM deleted d
	
	DELETE FROM tbl_Jobs WHERE Job_EmployerId=@Emp_Id
GO
/****** Object:  Trigger [tgr_AfterDeleteCandidate]    Script Date: 08/30/2017 15:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tgr_AfterDeleteCandidate] ON [dbo].[tbl_Candidate]
AFTER DELETE
AS
DECLARE @Cand_Id numeric(18,0);

	SELECT @Cand_Id=d.Cand_Id FROM deleted d
	
	DELETE FROM tbl_CandidateAppliedJobs WHERE Cand_Id=@Cand_Id
	DELETE FROM tbl_EmployerManageCandidateProfile WHERE Cand_Id=@Cand_Id
GO
/****** Object:  StoredProcedure [dbo].[sp_ManageEmployer]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ManageEmployer]
 @Emp_Id bigint
,@Emp_Name nvarchar(50)
,@Emp_Address nvarchar(max)
,@Emp_ContactPersonName nvarchar(50)
,@Emp_EmailId nvarchar(50)
,@Emp_MobileNumber nvarchar(50)
,@Emp_Place nvarchar(50)
,@Emp_LogoImage nvarchar(50)
,@Emp_DateTime datetime
,@Emp_Status bit
AS
BEGIN

	if(@Emp_Id=0)
		begin
			Insert into tbl_Employer(Emp_Name,Emp_Address,Emp_ContactPersonName,Emp_EmailId,Emp_MobileNumber,Emp_Place,Emp_LogoImage,Emp_DateTime,Emp_Status) values
									 (@Emp_Name,@Emp_Address,@Emp_ContactPersonName,@Emp_EmailId,@Emp_MobileNumber,@Emp_Place,@Emp_LogoImage,@Emp_DateTime,@Emp_Status);
		end
	else
		begin
			Update tbl_Employer SET
			 Emp_Name =@Emp_Name
			,Emp_Address =@Emp_Address
			,Emp_ContactPersonName =@Emp_ContactPersonName
			,Emp_EmailId =@Emp_EmailId
			,Emp_MobileNumber =@Emp_MobileNumber
			,Emp_Place =@Emp_Place
			,Emp_LogoImage =@Emp_LogoImage
			,Emp_DateTime =@Emp_DateTime
		   Where Emp_Id=@Emp_Id
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Candidate]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Delete_Candidate]
 @Cand_Id numeric(18,0)
AS
BEGIN
	Delete From tbl_Candidate where Cand_Id=@Cand_Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Employer]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Delete_Employer]
 @Emp_Id bigint
AS
BEGIN
	Delete From tbl_Employer where Emp_Id=@Emp_Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCandidate]    Script Date: 08/30/2017 15:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetCandidate]
 @Cand_Id numeric(18,0)
,@Cand_CategoryId bigint
,@Cand_LocationId bigint
,@Cand_ExpLevelId bigint
,@Cand_Name nvarchar(50)
,@skills nvarchar(50)

AS
BEGIN

	--CREATE TABLE #tblResultReturn(
	-- Cand_Id numeric(18,0)
	--,Cand_CategoryId bigInt
	--,Cand_LocationId bigInt
	--,Cand_ExpLevelId bigInt
	--,Cand_Name nvarchar(50)
	--,Cand_UserName nvarchar(50)
	--,Cand_Password nvarchar(50)
	--,Cand_EmailId nvarchar(50)
	--,Cand_MobileNumber nvarchar(50)
	--,Cand_Address nvarchar(50)
	--,Cand_HighestQualification nvarchar(50)
	--,Cand_SkillDescription nvarchar(max)
	--,Cand_Resume nvarchar(50)
	--,Cand_DateTime datetime)

	--Declare @Query varchar(50)='where';
	--if(@Cand_Id!=0)
	--	set @Query=@Query+'Cand_Id='+@Cand_Id+'';
	--if(@Cand_CategoryId!=0)
	--	set @Query=@Query+'Cand_CategoryId='+@Cand_CategoryId+'';
	--if(@Cand_LocationId!=0)
	--	set @Query=@Query+'Cand_LocationId='+@Cand_LocationId+'';
	--if(@Cand_ExpLevelId!=0)
	--	set @Query=@Query+'Cand_ExpLevelId='+@Cand_ExpLevelId+'';
	--if(@Cand_Name!='')
	--	set @Query='Cand_Name='+@Cand_Name+'';
	--if(@skills!='')
	--	set @Query=@Query+'Cand_SkillDescription LIKE "%'+@skills+'%"';
		
	--set @Query='SELECT * FROM tbl_Candidate '+@Query+'';
	--INSERT into #tblResultReturn 
	--Execute(@query)
	--Select * From #tblResultReturn
	--Drop table #tblResultReturn
	
	Select * from tbl_Candidate
END
GO
