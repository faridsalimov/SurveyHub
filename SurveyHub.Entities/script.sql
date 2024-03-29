USE [master]
GO
/****** Object:  Database [SurveyHubDB]    Script Date: 10.03.2024 02:43:29 ******/
CREATE DATABASE [SurveyHubDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SurveyHubDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SurveyHubDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SurveyHubDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SurveyHubDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SurveyHubDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SurveyHubDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SurveyHubDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SurveyHubDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SurveyHubDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SurveyHubDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SurveyHubDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SurveyHubDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SurveyHubDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SurveyHubDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SurveyHubDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SurveyHubDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SurveyHubDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SurveyHubDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SurveyHubDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SurveyHubDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SurveyHubDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SurveyHubDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SurveyHubDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SurveyHubDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SurveyHubDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SurveyHubDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SurveyHubDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SurveyHubDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SurveyHubDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SurveyHubDB] SET  MULTI_USER 
GO
ALTER DATABASE [SurveyHubDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SurveyHubDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SurveyHubDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SurveyHubDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SurveyHubDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SurveyHubDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SurveyHubDB', N'ON'
GO
ALTER DATABASE [SurveyHubDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [SurveyHubDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SurveyHubDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10.03.2024 02:43:29 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Options]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Options](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyId] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responses]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyId] [int] NOT NULL,
	[OptionId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Responses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Surveys]    Script Date: 10.03.2024 02:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Surveys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[PublishTime] [datetime2](7) NOT NULL,
	[CreatorId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Surveys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240309185255_Init', N'6.0.24')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9b491254-8824-4577-9af5-adf4912b887b', N'Admin', N'ADMIN', N'c77f68ef-6477-4b2d-9e4d-0cdf0975d9cc')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e795346f-58be-4529-97bb-838e805e2d58', N'User', N'USER', N'202a5a28-708f-4835-9c7c-eebdb7008402')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5cd07991-8c5d-4951-93c4-c493a63475de', N'9b491254-8824-4577-9af5-adf4912b887b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3b76143d-8a34-41d6-82c9-c917b6cf8393', N'e795346f-58be-4529-97bb-838e805e2d58')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5cd07991-8c5d-4951-93c4-c493a63475de', N'e795346f-58be-4529-97bb-838e805e2d58')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'747c7862-306e-4f38-bc27-4d0301209ea7', N'e795346f-58be-4529-97bb-838e805e2d58')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Surname], [ImageUrl], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3b76143d-8a34-41d6-82c9-c917b6cf8393', N'Fuad', N'Selimov', N'no-profile.jpg', N'fuad38', N'FUAD38', N'selimovferid85@gmail.com', N'SELIMOVFERID85@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEP7mKNRV7rTjP6SMLk8URbXKkBRw7WfAK78qZFMazdms6uXJgqDwVg/jk7fWovQSvA==', N'WQHEROEG4Q35ACBKFD42CQG6KAMDS33Z', N'0d80b963-32f6-44fd-b460-66ceef7f12b0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Surname], [ImageUrl], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5cd07991-8c5d-4951-93c4-c493a63475de', N'Farid', N'Salimov', N'no-profile.jpg', N'faridsalimov', N'FARIDSALIMOV', N'farid@gmail.com', N'FARID@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL9b+671wfcmkz+uQA6krUPOFEOPt4JfJz0ve107T+abRP+4ExnsBJsBu8M2nejGXw==', N'RRQ5PNT4KHSMMYOAIHL5NKBPJJCH6X43', N'704bd1c3-da89-4b6e-b013-0b9304d8a41d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Surname], [ImageUrl], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'747c7862-306e-4f38-bc27-4d0301209ea7', N'Rinat', N'Qedimov', N'no-profile.jpg', N'rinat', N'RINAT', N'rinat57@gmail.com', N'RINAT57@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENbGsioQYjia7OuU3twqufaH9Eqry015r5ETyG3DUbTNko011sqUHC3Itjpo/Dw6fQ==', N'ZWMNCL4Y4ZGV7NCMBYR72TQRYEEKE4TE', N'0f2f7938-ac76-480b-ba5f-ce38bb5a239c', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Options] ON 

INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (1, 1, N'1')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (2, 1, N'2')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (3, 1, N'3')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (4, 1, N'4')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (5, 2, N'Obyekt')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (6, 2, N'Eded')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (7, 2, N'Boolean')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (8, 2, N'Setir')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (9, 3, N'He')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (10, 3, N'Yox')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (11, 4, N'Ela')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (12, 4, N'Yaxsi')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (13, 4, N'Normal')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (14, 4, N'Pis')
INSERT [dbo].[Options] ([Id], [SurveyId], [Text]) VALUES (15, 4, N'Berbad')
SET IDENTITY_INSERT [dbo].[Options] OFF
GO
SET IDENTITY_INSERT [dbo].[Responses] ON 

INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (1, 2, 7, N'747c7862-306e-4f38-bc27-4d0301209ea7')
INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (2, 1, 2, N'747c7862-306e-4f38-bc27-4d0301209ea7')
INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (3, 4, 11, N'747c7862-306e-4f38-bc27-4d0301209ea7')
INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (4, 4, 11, N'3b76143d-8a34-41d6-82c9-c917b6cf8393')
INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (5, 4, 11, N'5cd07991-8c5d-4951-93c4-c493a63475de')
INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (6, 3, 9, N'5cd07991-8c5d-4951-93c4-c493a63475de')
INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (7, 2, 8, N'5cd07991-8c5d-4951-93c4-c493a63475de')
INSERT [dbo].[Responses] ([Id], [SurveyId], [OptionId], [UserId]) VALUES (8, 1, 1, N'5cd07991-8c5d-4951-93c4-c493a63475de')
SET IDENTITY_INSERT [dbo].[Responses] OFF
GO
SET IDENTITY_INSERT [dbo].[Surveys] ON 

INSERT [dbo].[Surveys] ([Id], [Content], [Category], [CategoryId], [PublishTime], [CreatorId]) VALUES (1, N'Farad', NULL, 1, CAST(N'2024-03-09T23:23:10.9046475' AS DateTime2), N'5cd07991-8c5d-4951-93c4-c493a63475de')
INSERT [dbo].[Surveys] ([Id], [Content], [Category], [CategoryId], [PublishTime], [CreatorId]) VALUES (2, N'String nedir?', NULL, 1, CAST(N'2024-03-09T23:38:29.1853326' AS DateTime2), N'747c7862-306e-4f38-bc27-4d0301209ea7')
INSERT [dbo].[Surveys] ([Id], [Content], [Category], [CategoryId], [PublishTime], [CreatorId]) VALUES (3, N'Sabahki oyuna gedeceksiz?', NULL, 2, CAST(N'2024-03-10T01:34:11.9601968' AS DateTime2), N'747c7862-306e-4f38-bc27-4d0301209ea7')
INSERT [dbo].[Surveys] ([Id], [Content], [Category], [CategoryId], [PublishTime], [CreatorId]) VALUES (4, N'Heyat necedir?', NULL, 10, CAST(N'2024-03-10T01:34:57.9830619' AS DateTime2), N'747c7862-306e-4f38-bc27-4d0301209ea7')
SET IDENTITY_INSERT [dbo].[Surveys] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10.03.2024 02:43:30 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10.03.2024 02:43:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10.03.2024 02:43:30 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10.03.2024 02:43:30 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10.03.2024 02:43:30 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10.03.2024 02:43:30 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10.03.2024 02:43:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Responses_UserId]    Script Date: 10.03.2024 02:43:30 ******/
CREATE NONCLUSTERED INDEX [IX_Responses_UserId] ON [dbo].[Responses]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Surveys_CreatorId]    Script Date: 10.03.2024 02:43:30 ******/
CREATE NONCLUSTERED INDEX [IX_Surveys_CreatorId] ON [dbo].[Surveys]
(
	[CreatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Responses]  WITH CHECK ADD  CONSTRAINT [FK_Responses_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Responses] CHECK CONSTRAINT [FK_Responses_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Surveys]  WITH CHECK ADD  CONSTRAINT [FK_Surveys_AspNetUsers_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Surveys] CHECK CONSTRAINT [FK_Surveys_AspNetUsers_CreatorId]
GO
USE [master]
GO
ALTER DATABASE [SurveyHubDB] SET  READ_WRITE 
GO
