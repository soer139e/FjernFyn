USE [master]
GO
/****** Object:  Database [FFdb]    Script Date: 2/19/2025 1:15:39 PM ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 2/19/2025 1:15:40 PM ******/
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
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (1, N'john1234', N'password123', N'john1234@fjernvarmefyn.dk', N'Administration', N'John Doe')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (2, N'alice5678', N'securePass456', N'alice5678@fjernvarmefyn.dk', N'IT', N'Alice Jensen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (3, N'mikk1234', N'mypassword789', N'mikk1234@fjernvarmefyn.dk', N'Administration', N'Mikkel Pedersen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (4, N'lise4321', N'lisePass321', N'lise4321@fjernvarmefyn.dk', N'HR', N'Lise Christensen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (5, N'pete8765', N'strongPass999', N'pete8765@fjernvarmefyn.dk', N'IT', N'Peter Hansen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (6, N'MFR', N'fvfitwu', N'MFR@fjernvarmefyn.dk', N'IT', N'Martin Fromese Romersen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (7, N'jt', N'fvfitdos', N'jt@fjernvarmefyn.dk', N'IT', N'Jens Tinkerholm')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (8, N'uty', N'bb', NULL, N'IT', N'Martin Fromese Romersen')
INSERT [dbo].[Employees] ([id], [userName], [passWord], [email], [department], [Name]) VALUES (9, N'admin', N'123', 'Administration@fjernvarmefyn.dk', N'Administration', N'Admininstration Test Konto')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
USE [master]
GO
ALTER DATABASE [FFdb] SET  READ_WRITE 
GO
