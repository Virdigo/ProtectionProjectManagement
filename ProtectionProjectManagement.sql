USE [master]
GO
/****** Object:  Database [ProtectionProjectManagement]    Script Date: 21.02.2025 20:57:04 ******/
CREATE DATABASE [ProtectionProjectManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProjectManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProjectManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProtectionProjectManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProtectionProjectManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProtectionProjectManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProtectionProjectManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProtectionProjectManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProtectionProjectManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProtectionProjectManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProtectionProjectManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ProtectionProjectManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProtectionProjectManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProtectionProjectManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProtectionProjectManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProtectionProjectManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProtectionProjectManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProtectionProjectManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProtectionProjectManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProtectionProjectManagement]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doljnosti]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doljnosti](
	[id_doljnosti] [int] IDENTITY(1,1) NOT NULL,
	[Post] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Doljnosti] PRIMARY KEY CLUSTERED 
(
	[id_doljnosti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoljnostiEmployees]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoljnostiEmployees](
	[EmployeeID] [int] NOT NULL,
	[PostID] [int] NOT NULL,
 CONSTRAINT [PK_DoljnostiEmployees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id_login] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id_login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectEmployees]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectEmployees](
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectEmployees] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](max) NOT NULL,
	[CustomerCompanyID] [int] NOT NULL,
	[ContractorCompanyID] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Priority] [int] NOT NULL,
	[ProjectManagerID] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 21.02.2025 20:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](max) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[PerformerID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (1, N'TechCorp')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (2, N'BuildIt Ltd')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (3, N'SoftSolutions')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (4, N'GlobalTech')
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Doljnosti] ON 

INSERT [dbo].[Doljnosti] ([id_doljnosti], [Post]) VALUES (1, N'Руководитель')
INSERT [dbo].[Doljnosti] ([id_doljnosti], [Post]) VALUES (2, N'Менеджер проекта')
INSERT [dbo].[Doljnosti] ([id_doljnosti], [Post]) VALUES (3, N'Сотрудник')
SET IDENTITY_INSERT [dbo].[Doljnosti] OFF
GO
INSERT [dbo].[DoljnostiEmployees] ([EmployeeID], [PostID]) VALUES (1, 1)
INSERT [dbo].[DoljnostiEmployees] ([EmployeeID], [PostID]) VALUES (4, 1)
INSERT [dbo].[DoljnostiEmployees] ([EmployeeID], [PostID]) VALUES (2, 2)
INSERT [dbo].[DoljnostiEmployees] ([EmployeeID], [PostID]) VALUES (3, 2)
INSERT [dbo].[DoljnostiEmployees] ([EmployeeID], [PostID]) VALUES (1, 3)
INSERT [dbo].[DoljnostiEmployees] ([EmployeeID], [PostID]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [MiddleName], [Email]) VALUES (1, N'Alice', N'Johnson', N'M.', N'alice.johnson@example.com')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [MiddleName], [Email]) VALUES (2, N'Bob', N'Smith', N'J.', N'bob.smith@example.com')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [MiddleName], [Email]) VALUES (3, N'Charlie', N'Brown', N'L.', N'charlie.brown@example.com')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [MiddleName], [Email]) VALUES (4, N'Diana', N'White', N'K.', N'diana.white@example.com')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([id_login], [Login], [Password], [EmployeeID]) VALUES (1, N'user1234', N'P@ssw0rd!2025', 1)
INSERT [dbo].[Login] ([id_login], [Login], [Password], [EmployeeID]) VALUES (2, N'cool_cat88', N'C@tLover#88', 2)
INSERT [dbo].[Login] ([id_login], [Login], [Password], [EmployeeID]) VALUES (3, N'sunny_day56', N'Sun$hine2025!', 3)
SET IDENTITY_INSERT [dbo].[Login] OFF
GO
INSERT [dbo].[ProjectEmployees] ([ProjectID], [EmployeeID]) VALUES (1, 1)
INSERT [dbo].[ProjectEmployees] ([ProjectID], [EmployeeID]) VALUES (1, 2)
INSERT [dbo].[ProjectEmployees] ([ProjectID], [EmployeeID]) VALUES (2, 3)
INSERT [dbo].[ProjectEmployees] ([ProjectID], [EmployeeID]) VALUES (2, 4)
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [CustomerCompanyID], [ContractorCompanyID], [StartDate], [EndDate], [Priority], [ProjectManagerID]) VALUES (1, N'AI Development', 1, 2, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [CustomerCompanyID], [ContractorCompanyID], [StartDate], [EndDate], [Priority], [ProjectManagerID]) VALUES (2, N'Cloud Migration', 3, 4, CAST(N'2023-05-10T00:00:00.0000000' AS DateTime2), CAST(N'2024-05-09T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [CustomerCompanyID], [ContractorCompanyID], [StartDate], [EndDate], [Priority], [ProjectManagerID]) VALUES (4, N'1', 1, 1, CAST(N'2025-02-18T08:29:39.0160000' AS DateTime2), CAST(N'2025-02-18T08:29:39.0160000' AS DateTime2), 1, 1)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [CustomerCompanyID], [ContractorCompanyID], [StartDate], [EndDate], [Priority], [ProjectManagerID]) VALUES (5, N'1', 1, 1, CAST(N'2025-02-19T00:00:00.0000000' AS DateTime2), CAST(N'2025-02-19T00:00:00.0000000' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([TaskID], [TaskName], [AuthorID], [PerformerID], [ProjectID], [Status], [Comment], [Priority]) VALUES (1, N'Set up cloud infrastructure', 1, 3, 2, N'ToDo', N'Initial setup', 1)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [AuthorID], [PerformerID], [ProjectID], [Status], [Comment], [Priority]) VALUES (2, N'Develop AI model', 2, 4, 1, N'InProgress', N'Training phase', 2)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [AuthorID], [PerformerID], [ProjectID], [Status], [Comment], [Priority]) VALUES (3, N'Testing AI accuracy', 3, 1, 1, N'Done', N'Testing in progress', 3)
INSERT [dbo].[Tasks] ([TaskID], [TaskName], [AuthorID], [PerformerID], [ProjectID], [Status], [Comment], [Priority]) VALUES (6, N'2', 1, 1, 1, N'1', N'1', 10)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
/****** Object:  Index [IX_DoljnostiEmployees_PostID]    Script Date: 21.02.2025 20:57:04 ******/
CREATE NONCLUSTERED INDEX [IX_DoljnostiEmployees_PostID] ON [dbo].[DoljnostiEmployees]
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectEmployees_EmployeeID]    Script Date: 21.02.2025 20:57:04 ******/
CREATE NONCLUSTERED INDEX [IX_ProjectEmployees_EmployeeID] ON [dbo].[ProjectEmployees]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projects_CustomerCompanyID]    Script Date: 21.02.2025 20:57:04 ******/
CREATE NONCLUSTERED INDEX [IX_Projects_CustomerCompanyID] ON [dbo].[Projects]
(
	[CustomerCompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projects_ProjectManagerID]    Script Date: 21.02.2025 20:57:04 ******/
CREATE NONCLUSTERED INDEX [IX_Projects_ProjectManagerID] ON [dbo].[Projects]
(
	[ProjectManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_PerformerID]    Script Date: 21.02.2025 20:57:04 ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_PerformerID] ON [dbo].[Tasks]
(
	[PerformerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_ProjectID]    Script Date: 21.02.2025 20:57:04 ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_ProjectID] ON [dbo].[Tasks]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DoljnostiEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DoljnostiEmployees_Doljnosti_PostID] FOREIGN KEY([PostID])
REFERENCES [dbo].[Doljnosti] ([id_doljnosti])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DoljnostiEmployees] CHECK CONSTRAINT [FK_DoljnostiEmployees_Doljnosti_PostID]
GO
ALTER TABLE [dbo].[DoljnostiEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DoljnostiEmployees_Employees_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DoljnostiEmployees] CHECK CONSTRAINT [FK_DoljnostiEmployees_Employees_EmployeeID]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Employees]
GO
ALTER TABLE [dbo].[ProjectEmployees]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEmployees_Employees_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectEmployees] CHECK CONSTRAINT [FK_ProjectEmployees_Employees_EmployeeID]
GO
ALTER TABLE [dbo].[ProjectEmployees]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEmployees_Projects_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectEmployees] CHECK CONSTRAINT [FK_ProjectEmployees_Projects_ProjectID]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Companies_CustomerCompanyID] FOREIGN KEY([CustomerCompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Companies_CustomerCompanyID]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Employees_ProjectManagerID] FOREIGN KEY([ProjectManagerID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Employees_ProjectManagerID]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Employees_PerformerID] FOREIGN KEY([PerformerID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Employees_PerformerID]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Projects_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Projects_ProjectID]
GO
USE [master]
GO
ALTER DATABASE [ProtectionProjectManagement] SET  READ_WRITE 
GO
