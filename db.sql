USE [master]
GO
/****** Object:  Database [pms]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE DATABASE [pms]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pms', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pms.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pms_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pms_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [pms] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pms] SET ARITHABORT OFF 
GO
ALTER DATABASE [pms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [pms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pms] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [pms] SET  MULTI_USER 
GO
ALTER DATABASE [pms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pms] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pms] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pms] SET QUERY_STORE = OFF
GO
USE [pms]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amenities]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Icon] [nvarchar](max) NULL,
 CONSTRAINT [PK_Amenities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppLogs]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
	[Actionid] [int] NOT NULL,
	[ActionName] [nvarchar](max) NULL,
	[ActorIdentity] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chains]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chains](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[ManagerId] [int] NOT NULL,
 CONSTRAINT [PK_Chains] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelAmenity]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelAmenity](
	[HotelId] [int] NOT NULL,
	[AmenityId] [int] NOT NULL,
 CONSTRAINT [PK_HotelAmenity] PRIMARY KEY CLUSTERED 
(
	[AmenityId] ASC,
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[Name] [nvarchar](450) NULL,
	[Description] [nvarchar](200) NULL,
	[ManagerId] [int] NOT NULL,
	[ChainId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[Address] [nvarchar](450) NOT NULL,
	[Country] [nvarchar](450) NOT NULL,
	[City] [nvarchar](450) NOT NULL,
	[PostalCode] [int] NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAmenity]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAmenity](
	[RoomId] [int] NOT NULL,
	[AmenityId] [int] NOT NULL,
 CONSTRAINT [PK_RoomAmenity] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC,
	[AmenityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[HotelId] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01-Jul-20 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200701160618_init', N'3.1.5')
GO
SET IDENTITY_INSERT [dbo].[Amenities] ON 

INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (1, CAST(N'2020-07-01T18:38:10.5831633' AS DateTime2), NULL, NULL, 1, N'Wifi1', N'Wifi', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (2, CAST(N'2020-07-01T18:38:23.9286850' AS DateTime2), NULL, NULL, 1, N'Pool', N'Pool', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (3, CAST(N'2020-07-01T18:38:31.3793385' AS DateTime2), NULL, NULL, 1, N'bath', N'bath', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (4, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'djakuzi', N'asdsadas', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (6, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'phone', N'phone', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (7, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'internet', N'net', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (8, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'tennis', N'sports', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (9, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'basketball', N'sports', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (11, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'tabletennis', N'sports', N'')
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (12, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'swimming', N'sports', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (13, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'chess', N'tournament', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (14, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'affiliates', N'affiliates', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (15, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'caffe', N'caffe', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (16, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'open bar', N'bar', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (17, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'drinks', N'alcohol', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (18, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'bordel', N'macro', NULL)
INSERT [dbo].[Amenities] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [Icon]) VALUES (19, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'strip club', N'great', NULL)
SET IDENTITY_INSERT [dbo].[Amenities] OFF
GO
SET IDENTITY_INSERT [dbo].[AppLogs] ON 

INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (1, CAST(N'2020-07-01T18:38:09.9533649' AS DateTime2), NULL, NULL, 1, 2, 11, N'Create amenity', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (2, CAST(N'2020-07-01T18:38:13.0326230' AS DateTime2), NULL, NULL, 1, 2, 11, N'Create amenity', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (3, CAST(N'2020-07-01T18:38:23.9193786' AS DateTime2), NULL, NULL, 1, 2, 11, N'Create amenity', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (4, CAST(N'2020-07-01T18:38:31.3755615' AS DateTime2), NULL, NULL, 1, 2, 11, N'Create amenity', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (5, CAST(N'2020-07-01T18:38:47.8433511' AS DateTime2), NULL, NULL, 1, 2, 23, N'Create user', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (6, CAST(N'2020-07-01T18:38:55.7826711' AS DateTime2), NULL, NULL, 1, 2, 4, N'Create a chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (7, CAST(N'2020-07-01T18:39:08.6729623' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (8, CAST(N'2020-07-01T18:39:10.1152217' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (9, CAST(N'2020-07-01T18:39:46.4993443' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (10, CAST(N'2020-07-01T18:39:53.9756829' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (11, CAST(N'2020-07-01T18:40:14.8313760' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (12, CAST(N'2020-07-01T18:40:16.8451785' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (13, CAST(N'2020-07-01T18:40:55.6569914' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (14, CAST(N'2020-07-01T18:41:26.8256202' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (15, CAST(N'2020-07-01T18:46:55.1044430' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (16, CAST(N'2020-07-01T18:54:14.5113714' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (17, CAST(N'2020-07-01T18:55:11.5575412' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (18, CAST(N'2020-07-01T18:55:13.8151123' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (19, CAST(N'2020-07-01T19:15:18.9740750' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (20, CAST(N'2020-07-01T19:15:35.2501842' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (21, CAST(N'2020-07-01T19:15:37.5539149' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (22, CAST(N'2020-07-01T19:16:35.0503353' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (23, CAST(N'2020-07-01T19:30:25.7511141' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (24, CAST(N'2020-07-01T19:33:40.1914942' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (25, CAST(N'2020-07-01T19:34:42.5818537' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (26, CAST(N'2020-07-01T19:35:20.0211338' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (27, CAST(N'2020-07-01T19:39:16.5347065' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (28, CAST(N'2020-07-01T19:40:42.6911565' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (29, CAST(N'2020-07-01T19:41:59.4081851' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (30, CAST(N'2020-07-01T19:46:03.7967110' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (31, CAST(N'2020-07-01T19:47:54.5223903' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (32, CAST(N'2020-07-01T19:51:47.1494487' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (33, CAST(N'2020-07-01T19:52:22.3232908' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (34, CAST(N'2020-07-01T19:53:21.7796781' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (35, CAST(N'2020-07-01T19:55:18.0292267' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (36, CAST(N'2020-07-01T20:03:21.7573238' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (37, CAST(N'2020-07-01T20:03:29.9211478' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (38, CAST(N'2020-07-01T20:03:56.3839361' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (39, CAST(N'2020-07-01T20:03:57.3697002' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (40, CAST(N'2020-07-01T20:03:58.0449077' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (41, CAST(N'2020-07-01T20:04:38.8170135' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (42, CAST(N'2020-07-01T20:05:27.0813445' AS DateTime2), NULL, NULL, 1, 2, 16, N'Edit a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (43, CAST(N'2020-07-01T20:09:10.0761624' AS DateTime2), NULL, NULL, 1, 2, 15, N'Create a hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (44, CAST(N'2020-07-01T20:10:33.5759380' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (45, CAST(N'2020-07-01T20:10:41.8645086' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (46, CAST(N'2020-07-01T20:10:44.4244923' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (47, CAST(N'2020-07-01T20:11:57.1197936' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (48, CAST(N'2020-07-01T20:12:06.8726637' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (49, CAST(N'2020-07-01T20:12:44.9100281' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (50, CAST(N'2020-07-01T20:13:13.3393671' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (51, CAST(N'2020-07-01T20:13:17.9939315' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (52, CAST(N'2020-07-01T20:15:33.3638837' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (53, CAST(N'2020-07-01T20:15:59.4104215' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (54, CAST(N'2020-07-01T20:17:36.4986704' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (55, CAST(N'2020-07-01T20:19:16.7093882' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (56, CAST(N'2020-07-01T20:19:59.2185688' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (57, CAST(N'2020-07-01T20:21:31.2691449' AS DateTime2), NULL, NULL, 1, 2, 18, N'Create a room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (58, CAST(N'2020-07-01T20:28:10.0487077' AS DateTime2), NULL, NULL, 1, 2, 22, N'Edit room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (59, CAST(N'2020-07-01T20:28:21.7944662' AS DateTime2), NULL, NULL, 1, 2, 22, N'Edit room', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (60, CAST(N'2020-07-01T22:10:22.4342440' AS DateTime2), NULL, NULL, 1, 2, 1, N'List all hotels', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (61, CAST(N'2020-07-01T22:12:02.1005774' AS DateTime2), NULL, NULL, 1, 2, 1, N'List all hotels', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (62, CAST(N'2020-07-01T22:13:19.6927960' AS DateTime2), NULL, NULL, 1, 2, 15, N'Fetch single hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (63, CAST(N'2020-07-01T22:15:44.3828280' AS DateTime2), NULL, NULL, 1, 2, 15, N'Fetch single hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (64, CAST(N'2020-07-01T22:18:01.3142358' AS DateTime2), NULL, NULL, 1, 2, 15, N'Fetch single hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (65, CAST(N'2020-07-01T22:18:12.5312739' AS DateTime2), NULL, NULL, 1, 2, 15, N'Fetch single hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (66, CAST(N'2020-07-01T22:18:15.2510918' AS DateTime2), NULL, NULL, 1, 2, 15, N'Fetch single hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (67, CAST(N'2020-07-01T22:18:46.6902974' AS DateTime2), NULL, NULL, 1, 2, 15, N'Fetch single hotel', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (68, CAST(N'2020-07-01T22:23:15.0282840' AS DateTime2), NULL, NULL, 1, 2, 2, N'Get all chains', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (69, CAST(N'2020-07-01T22:24:03.7196878' AS DateTime2), NULL, NULL, 1, 2, 2, N'Get all chains', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (70, CAST(N'2020-07-01T22:24:47.9497833' AS DateTime2), NULL, NULL, 1, 2, 2, N'Get all chains', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (71, CAST(N'2020-07-01T22:24:55.6597793' AS DateTime2), NULL, NULL, 1, 2, 2, N'Get all chains', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (72, CAST(N'2020-07-01T22:24:59.9038046' AS DateTime2), NULL, NULL, 1, 2, 3, N'Get single chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (73, CAST(N'2020-07-01T22:25:20.1888944' AS DateTime2), NULL, NULL, 1, 2, 3, N'Get single chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (74, CAST(N'2020-07-01T22:26:04.8283151' AS DateTime2), NULL, NULL, 1, 2, 3, N'Get single chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (75, CAST(N'2020-07-01T22:26:38.8079698' AS DateTime2), NULL, NULL, 1, 2, 3, N'Get single chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (76, CAST(N'2020-07-01T22:27:58.6359300' AS DateTime2), NULL, NULL, 1, 2, 3, N'Get single chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (77, CAST(N'2020-07-01T22:31:07.6307770' AS DateTime2), NULL, NULL, 1, 2, 3, N'Get single chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (78, CAST(N'2020-07-01T22:31:25.2176663' AS DateTime2), NULL, NULL, 1, 2, 7, N'Edit a Chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (79, CAST(N'2020-07-01T22:31:33.3110815' AS DateTime2), NULL, NULL, 1, 2, 7, N'Edit a Chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (80, CAST(N'2020-07-01T22:31:40.1581826' AS DateTime2), NULL, NULL, 1, 2, 7, N'Edit a Chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (81, CAST(N'2020-07-01T22:32:20.2598540' AS DateTime2), NULL, NULL, 1, 2, 4, N'Create a chain', N'Hotel Manager')
INSERT [dbo].[AppLogs] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [UserId], [Actionid], [ActionName], [ActorIdentity]) VALUES (82, CAST(N'2020-07-01T22:32:33.4516546' AS DateTime2), NULL, NULL, 1, 2, 8, N'Delete chain', N'Hotel Manager')
SET IDENTITY_INSERT [dbo].[AppLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Chains] ON 

INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (1, CAST(N'2020-07-01T18:38:55.8077770' AS DateTime2), NULL, NULL, 1, N'Chain1', 1)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (2, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Chain2', 3)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (4, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Name chain', 6)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (5, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), CAST(N'2020-07-01T22:31:40.1754319' AS DateTime2), NULL, 1, N'Edited', 3)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (6, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Death', 8)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (8, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'ACDC', 10)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (10, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Yngwie', 11)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (11, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Rug', 12)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (13, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Dirt', 14)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (14, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Support', 15)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (15, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'helper', 16)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (16, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Method', 1)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (17, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'cirilo', 3)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (18, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'metodije', 15)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (20, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'park', 3)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (21, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'headset', 10)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (22, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'button', 11)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (24, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'helper1', 11)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (25, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'k1', 14)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (26, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'slypoo', 1)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (28, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'extravacancie', 3)
INSERT [dbo].[Chains] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [ManagerId]) VALUES (29, CAST(N'2020-07-01T22:32:20.2752149' AS DateTime2), CAST(N'2020-07-01T22:32:33.4673292' AS DateTime2), CAST(N'2020-07-01T22:32:33.4672536' AS DateTime2), 0, N'Create from postman', 1)
SET IDENTITY_INSERT [dbo].[Chains] OFF
GO
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (1, 2)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (1, 3)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (1, 4)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (1, 9)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (2, 1)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (2, 2)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (2, 3)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (2, 4)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (2, 7)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (2, 9)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (3, 1)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (3, 4)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (4, 1)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (4, 3)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (5, 1)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (5, 2)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (5, 4)
INSERT [dbo].[HotelAmenity] ([HotelId], [AmenityId]) VALUES (5, 6)
GO
SET IDENTITY_INSERT [dbo].[Hotels] ON 

INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (1, CAST(N'2020-07-01T18:39:08.7633245' AS DateTime2), NULL, NULL, 1, N'New hotel1123', NULL, 1, 1, 1)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (2, CAST(N'2020-07-01T18:40:14.8478100' AS DateTime2), NULL, NULL, 1, N'New hotel', NULL, 1, 1, 2)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (3, CAST(N'2020-07-01T18:55:12.2749479' AS DateTime2), NULL, NULL, 1, N'New hotel123', NULL, 1, 1, 3)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (4, CAST(N'2020-07-01T19:15:35.3339966' AS DateTime2), NULL, NULL, 1, N'New', NULL, 1, 1, 4)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (5, CAST(N'2020-07-01T19:16:35.8552716' AS DateTime2), CAST(N'2020-07-01T20:05:28.4398438' AS DateTime2), NULL, 1, N'EDITED', NULL, 1, 1, 5)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (10, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Hotel 1', NULL, 1, 5, 10)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (15, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Hotel 2', NULL, 23, 5, 11)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (18, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Hotel 3', NULL, 10, 4, 18)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (19, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Hotel 4', NULL, 10, 4, 19)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (20, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'hotel5 ', NULL, 10, 4, 20)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (22, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N' hotel 7 ', NULL, 1, 4, 22)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (24, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'hotel 24', NULL, 1, 4, 23)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (25, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'25 hotel', NULL, 1, 4, 25)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (26, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'hotel name', NULL, 1, 4, 26)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (27, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'hotel loc', NULL, 1, 4, 27)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (28, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Naziv', NULL, 1, 4, 28)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (37, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Crystal', NULL, 6, 5, 12)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (38, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'chuck', NULL, 6, 2, 13)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (42, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'george ', NULL, 7, 2, 17)
INSERT [dbo].[Hotels] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [ManagerId], [ChainId], [LocationId]) VALUES (45, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'fisher', NULL, 8, 2, 21)
SET IDENTITY_INSERT [dbo].[Hotels] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (1, CAST(N'2020-07-01T18:39:08.7633301' AS DateTime2), NULL, NULL, 1, N'Takovska 51', N'Serbia', N'Belgrade', 11000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (2, CAST(N'2020-07-01T18:40:14.8478312' AS DateTime2), NULL, NULL, 1, N'Takovska 50', N'Serbia', N'Belgrade', 11000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (3, CAST(N'2020-07-01T18:55:12.2749589' AS DateTime2), NULL, NULL, 1, N'Takovksa 20', N'Serbia', N'Dubrovnik', 11050)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (4, CAST(N'2020-07-01T19:15:35.3340057' AS DateTime2), NULL, NULL, 1, N'Carli Caplina', N'Serbia', N'Novi Pazar', 13131)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (5, CAST(N'2020-07-01T19:16:35.8552814' AS DateTime2), NULL, NULL, 1, N'Random ', N'Hungary', N'Segedin', 98888)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (9, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Line', N'BiH', N'Sarajevo', 89999)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (10, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Command', N'Croatia', N'Vukovar', 100)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (11, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Fan', N'Serbia', N'Srem', 1000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (12, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Tissue', N'Germany', N'Berlin', 19222)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (13, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Asphalt', N'Belgium', N'Brussel', 12313)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (17, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Dimitrijala', N'Holland', N'Rotterdam', 11111)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (18, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Neznani', N'Serbia', N'Zrenjanin', 14000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (19, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Mala amerika', N'SAD', N'Minesota', 99000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (20, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Square', N'Italy', N'Milano', 20000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (21, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Square 2 ', N'Italy', N'Rome', 29000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (22, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Center', N'Spain', N'Madrid', 20000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (23, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Town', N'China', N'Peking', 90000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (25, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Ugao', N'Japan', N'Tokyo', 12345)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (26, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Ugao 1', N'Rusija', N'Moskva', 28998)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (27, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Tuna', N'Peru', N'Zimbabve', 23000)
INSERT [dbo].[Locations] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Address], [Country], [City], [PostalCode]) VALUES (28, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Kina', N'Kina', N'Kina', 28999)
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (4, 1)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (5, 1)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (4, 2)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (4, 3)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (6, 3)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (4, 4)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (1, 9)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (4, 9)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (1, 11)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (4, 11)
INSERT [dbo].[RoomAmenity] ([RoomId], [AmenityId]) VALUES (1, 12)
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (1, CAST(N'2020-07-01T20:10:41.8990210' AS DateTime2), NULL, NULL, 1, N'Room', N'description', 2)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (4, CAST(N'2020-07-01T20:13:13.3472983' AS DateTime2), CAST(N'2020-07-01T20:28:21.8703047' AS DateTime2), NULL, 1, N'Soba', N'Opis', 5)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (5, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Room 1', NULL, 1)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (6, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Soba', NULL, 3)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (7, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Bedroom', NULL, 4)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (8, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Analysis', NULL, 10)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (9, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Fan', NULL, 15)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (10, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Namaz grcki', NULL, 18)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (11, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'Fly away', NULL, 18)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (12, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'get overhere', NULL, 19)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (13, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'fatality', NULL, 1)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (14, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'brutality', NULL, 2)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (15, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'babality', NULL, 3)
INSERT [dbo].[Rooms] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Name], [Description], [HotelId]) VALUES (16, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'double', NULL, 2)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (1, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'email@example.com', N'Nikola', N'mitrovic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (3, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'admin@mail.com', N'Aleksandar', N'Mitrovic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (4, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'user@gmail.com', N'Ruzica', N'Mitrovic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (6, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'test@gmail.com', N'Milos', N'Mitrovic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (7, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'igor@gmail.com', N'Igor', N'Mitrovic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (8, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'tamara@gmail.com', N'Tamara', N'Djekic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (10, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'nevena@djekic.com', N'Nevena', N'Djekic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (11, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'tomislav@nikolic.com', N'Toma', N'Nikolic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (12, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'filip@mitrovic.co', N'Filip', N'Gogolijevic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (14, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'sale@prodaja.com', N'Real', N'Madrid')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (15, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'zoran@mih.com', N'Stefan', N'Mihajlovic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (16, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'sveta@djekic.com', N'Svetlana', N'Mihajlovic')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (17, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'ljubica@zivot.com', N'Ventilator', N'Sobni')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (18, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'slava@gmail.com', N'Slavko', N'Tajti')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (21, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'sareno@azan.com', N'Vlasac', N'Drveni')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (22, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'vaj@rm.fc', N'guti', N'ernandez')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (23, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'fox@hotmail.com', N'Ervin', N'Romel')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (24, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'steve@wonder.com', N'Does', N'Itknow')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (25, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'bird@box.com', N'Sandra', N'Bulok')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (26, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'vesli@snajps.co', N'Holivud', N'Stories')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (27, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'ben@del.com', N'Toro', N'Kom')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (28, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'granice@plana.com', N'Nutella', N'Ferrero')
INSERT [dbo].[Users] ([Id], [CreatedAt], [UpdatedAt], [DeletedAt], [isActive], [Email], [FirstName], [LastName]) VALUES (29, CAST(N'2020-07-01T18:38:47.8828995' AS DateTime2), NULL, NULL, 1, N'ssms@support.com', N'Call', N'Us')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Amenities_Name]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Amenities_Name] ON [dbo].[Amenities]
(
	[Name] ASC
)
WHERE ([Name] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Chains_ManagerId]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE NONCLUSTERED INDEX [IX_Chains_ManagerId] ON [dbo].[Chains]
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Chains_Name]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Chains_Name] ON [dbo].[Chains]
(
	[Name] ASC
)
WHERE ([Name] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HotelAmenity_HotelId]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE NONCLUSTERED INDEX [IX_HotelAmenity_HotelId] ON [dbo].[HotelAmenity]
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hotels_ChainId]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE NONCLUSTERED INDEX [IX_Hotels_ChainId] ON [dbo].[Hotels]
(
	[ChainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hotels_LocationId]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Hotels_LocationId] ON [dbo].[Hotels]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hotels_ManagerId]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE NONCLUSTERED INDEX [IX_Hotels_ManagerId] ON [dbo].[Hotels]
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Hotels_Name]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Hotels_Name] ON [dbo].[Hotels]
(
	[Name] ASC
)
WHERE ([Name] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Locations_City_Address_Country_PostalCode]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Locations_City_Address_Country_PostalCode] ON [dbo].[Locations]
(
	[City] ASC,
	[Address] ASC,
	[Country] ASC,
	[PostalCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomAmenity_AmenityId]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE NONCLUSTERED INDEX [IX_RoomAmenity_AmenityId] ON [dbo].[RoomAmenity]
(
	[AmenityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rooms_HotelId]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE NONCLUSTERED INDEX [IX_Rooms_HotelId] ON [dbo].[Rooms]
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 01-Jul-20 22:33:37 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Chains]  WITH CHECK ADD  CONSTRAINT [FK_Chains_Users_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Chains] CHECK CONSTRAINT [FK_Chains_Users_ManagerId]
GO
ALTER TABLE [dbo].[HotelAmenity]  WITH CHECK ADD  CONSTRAINT [FK_HotelAmenity_Amenities_AmenityId] FOREIGN KEY([AmenityId])
REFERENCES [dbo].[Amenities] ([Id])
GO
ALTER TABLE [dbo].[HotelAmenity] CHECK CONSTRAINT [FK_HotelAmenity_Amenities_AmenityId]
GO
ALTER TABLE [dbo].[HotelAmenity]  WITH CHECK ADD  CONSTRAINT [FK_HotelAmenity_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[HotelAmenity] CHECK CONSTRAINT [FK_HotelAmenity_Hotels_HotelId]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Chains_ChainId] FOREIGN KEY([ChainId])
REFERENCES [dbo].[Chains] ([Id])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_Chains_ChainId]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_Locations_LocationId]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Users_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_Users_ManagerId]
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_RoomAmenity_Amenities_AmenityId] FOREIGN KEY([AmenityId])
REFERENCES [dbo].[Amenities] ([Id])
GO
ALTER TABLE [dbo].[RoomAmenity] CHECK CONSTRAINT [FK_RoomAmenity_Amenities_AmenityId]
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_RoomAmenity_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[RoomAmenity] CHECK CONSTRAINT [FK_RoomAmenity_Rooms_RoomId]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Hotels_HotelId]
GO
USE [master]
GO
ALTER DATABASE [pms] SET  READ_WRITE 
GO
