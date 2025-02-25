USE [master]
GO
/****** Object:  Database [FFdb]    Script Date: 2/24/2025 2:18:27 PM ******/
CREATE DATABASE [FFdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FFdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FFdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FFdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FFdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FFdb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FFdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FFdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FFdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FFdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FFdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FFdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [FFdb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FFdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FFdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FFdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FFdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FFdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FFdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FFdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FFdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FFdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FFdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FFdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FFdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FFdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FFdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FFdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FFdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FFdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FFdb] SET  MULTI_USER 
GO
ALTER DATABASE [FFdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FFdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FFdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FFdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FFdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FFdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FFdb] SET QUERY_STORE = OFF
GO
USE [FFdb]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2/24/2025 2:18:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](10) NULL,
	[passWord] [nvarchar](30) NULL,
	[email] [nvarchar](30) NULL,
	[department] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 2/24/2025 2:18:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[Criticality] [nvarchar](20) NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[IsNew] [bit] NULL,
	[SoftwareID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Software]    Script Date: 2/24/2025 2:18:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Software](
	[SoftwareID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[SoftwareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (1, N'john1234', N'password123', N'john1234@fjernvarmefyn.dk', N'Administration', N'John Doe')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (2, N'alice5678', N'securePass456', N'alice5678@fjernvarmefyn.dk', N'IT', N'Alice Jensen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (3, N'mikk1234', N'mypassword789', N'mikk1234@fjernvarmefyn.dk', N'Administration', N'Mikkel Pedersen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (4, N'lise4321', N'lisePass321', N'lise4321@fjernvarmefyn.dk', N'HR', N'Lise Christensen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (5, N'pete8765', N'strongPass999', N'pete8765@fjernvarmefyn.dk', N'IT', N'Peter Hansen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (6, N'MFR', N'fvfitwu', N'MFR@fjernvarmefyn.dk', N'IT', N'Martin Fromese Romersen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (7, N'jt', N'fvfitdos', N'jt@fjernvarmefyn.dk', N'IT', N'Jens Tinkerholm')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (8, N'uty', N'bb', NULL, N'IT', N'Martin Fromese Romersen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (9, N'admin', N'123', N'admin@fjernvarmefyn.dk', N'Administration', N'Test administrator konto')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (3, N'High', N'Login Error on Outlook', N'Users are unable to log in to Outlook via Office 365. The page hangs indefinitely after entering credentials.', 1, 1, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (4, N'Medium', N'Image Quality Issue', N'When opening high-resolution images, Photoshop takes too long to load and sometimes the quality is degraded.', 1, 2, 2)
INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (5, N'Low', N'Notification Delay', N'Slack notifications are delayed by several minutes when the app is running in the background on mobile.', 1, 3, 3)
INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (6, N'Critical', N'Data Loss in Trello', N'Trello boards are randomly missing tasks after syncing, which causes critical data loss during project management.', 1, 4, 4)
INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (7, N'High', N'Slow Loading in Word', N'Microsoft Word takes an unusually long time to open documents with heavy formatting or embedded media.', 0, 1, 5)
INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (8, N'Medium', N'File Export Bug', N'Photoshop sometimes fails to export files in PNG format and the output is corrupted.', 0, 2, 6)
INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (9, N'Low', N'Message Syncing Issue', N'Slack messages are not syncing properly between devices, causing confusion when switching between desktop and mobile versions.', 1, 3, 7)
INSERT [dbo].[Feedback] ([FeedbackID], [Criticality], [Title], [Description], [IsNew], [SoftwareID], [EmployeeID]) VALUES (10, N'Critical', N'Security Vulnerability in Trello', N'Trello has an unpatched vulnerability that allows unauthorized users to view boards without proper permissions.', 0, 4, 8)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Software] ON 

INSERT [dbo].[Software] ([SoftwareID], [Name]) VALUES (1, N'Microsoft Office 365')
INSERT [dbo].[Software] ([SoftwareID], [Name]) VALUES (2, N'Adobe Photoshop')
INSERT [dbo].[Software] ([SoftwareID], [Name]) VALUES (3, N'Slack')
INSERT [dbo].[Software] ([SoftwareID], [Name]) VALUES (4, N'Trello')
SET IDENTITY_INSERT [dbo].[Software] OFF
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([SoftwareID])
REFERENCES [dbo].[Software] ([SoftwareID])
GO
USE [master]
GO
ALTER DATABASE [FFdb] SET  READ_WRITE 
GO
