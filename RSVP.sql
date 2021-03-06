USE [master]
GO
/****** Object:  Database [RSVP]    Script Date: 4/4/2020 1:58:29 PM ******/
CREATE DATABASE [RSVP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RSVP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\RSVP.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RSVP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\RSVP_log.ldf' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RSVP] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RSVP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RSVP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RSVP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RSVP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RSVP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RSVP] SET ARITHABORT OFF 
GO
ALTER DATABASE [RSVP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RSVP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RSVP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RSVP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RSVP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RSVP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RSVP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RSVP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RSVP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RSVP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RSVP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RSVP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RSVP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RSVP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RSVP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RSVP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RSVP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RSVP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RSVP] SET  MULTI_USER 
GO
ALTER DATABASE [RSVP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RSVP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RSVP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RSVP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [RSVP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RSVP', N'ON'
GO
ALTER DATABASE [RSVP] SET QUERY_STORE = OFF
GO
USE [RSVP]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 4/4/2020 1:58:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Subtitle] [varchar](100) NULL,
	[Description] [varchar](300) NULL,
	[EventStartDate] [date] NOT NULL,
	[EventEndDate] [date] NOT NULL,
	[Venue] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[EventStartTime] [time](7) NOT NULL,
	[EventEndTime] [time](7) NOT NULL,
	[Details] [varchar](300) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 4/4/2020 1:58:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[GuestID] [int] IDENTITY(1,1) NOT NULL,
	[GuestGroupID] [int] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[IsChild] [bit] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuestEventJunction]    Script Date: 4/4/2020 1:58:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuestEventJunction](
	[GuestID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
	[RepliesID] [int] NULL,
 CONSTRAINT [PK_GuestEventJunction] PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuestGroup]    Script Date: 4/4/2020 1:58:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuestGroup](
	[GuestGroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_GuestGroup] PRIMARY KEY CLUSTERED 
(
	[GuestGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Replies]    Script Date: 4/4/2020 1:58:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Replies](
	[RepliesID] [int] IDENTITY(1,1) NOT NULL,
	[Attending] [bit] NOT NULL,
	[AtendeeEmail] [nvarchar](50) NULL,
	[MealSelection] [nvarchar](100) NULL,
	[Notes] [nvarchar](max) NULL,
	[NeedParking] [bit] NULL,
 CONSTRAINT [PK_Replies] PRIMARY KEY CLUSTERED 
(
	[RepliesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventID], [Title], [Subtitle], [Description], [EventStartDate], [EventEndDate], [Venue], [Address], [EventStartTime], [EventEndTime], [Details]) VALUES (1, N'Ceremony', N'ceremony & brunch', N'Welcome drinks will be served at 10:00. Ceremony will commence at 10:30. Cocktails and hor d''oeuvres will be passed at 11:00. Brunch will be served at 12:30.', CAST(N'2020-08-30' AS Date), CAST(N'2020-08-30' AS Date), N'Graydon Hall Manor', N'185 Graydon Hall Drive, Toronto', CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), N'Free parking will be provided in the designated parking lot closest to the building. Signage will be present.')
INSERT [dbo].[Events] ([EventID], [Title], [Subtitle], [Description], [EventStartDate], [EventEndDate], [Venue], [Address], [EventStartTime], [EventEndTime], [Details]) VALUES (2, N'Reception', N'cocktails & dancing', N'Help us celebrate from 9:00 onwards with lots of drinks, dancing and a beautiful view.', CAST(N'2020-08-30' AS Date), CAST(N'2020-08-31' AS Date), N'The One Eighty', N'55 Bloor St W, 51st Floor, Toronto', CAST(N'21:00:00' AS Time), CAST(N'02:00:00' AS Time), N'Entrance to the restaurant is on the second floor, to the right of the escalators. Parking is available underneath the building. Entrance to the lot is on the (East side of Bay Street).')
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([GuestID], [GuestGroupID], [FirstName], [LastName], [IsChild]) VALUES (3, NULL, N'Lauren', N'Rosentzveig', 0)
INSERT [dbo].[Guest] ([GuestID], [GuestGroupID], [FirstName], [LastName], [IsChild]) VALUES (4, NULL, N'Jordana', N'Rosentzveig', 0)
SET IDENTITY_INSERT [dbo].[Guest] OFF
INSERT [dbo].[GuestEventJunction] ([GuestID], [EventID], [RepliesID]) VALUES (3, 1, NULL)
INSERT [dbo].[GuestEventJunction] ([GuestID], [EventID], [RepliesID]) VALUES (3, 2, NULL)
INSERT [dbo].[GuestEventJunction] ([GuestID], [EventID], [RepliesID]) VALUES (4, 1, NULL)
/****** Object:  Index [IX_Events]    Script Date: 4/4/2020 1:58:29 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Events] ON [dbo].[Events]
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Guest] ADD  CONSTRAINT [DF_Guest_IsChild]  DEFAULT ((0)) FOR [IsChild]
GO
ALTER TABLE [dbo].[Replies] ADD  CONSTRAINT [DF_Replies_NeedParking]  DEFAULT ((0)) FOR [NeedParking]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_GuestGroup] FOREIGN KEY([GuestGroupID])
REFERENCES [dbo].[GuestGroup] ([GuestGroupID])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_GuestGroup]
GO
ALTER TABLE [dbo].[GuestEventJunction]  WITH CHECK ADD  CONSTRAINT [FK_GuestEventJunction_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[GuestEventJunction] CHECK CONSTRAINT [FK_GuestEventJunction_Events]
GO
ALTER TABLE [dbo].[GuestEventJunction]  WITH CHECK ADD  CONSTRAINT [FK_GuestEventJunction_Guest] FOREIGN KEY([GuestID])
REFERENCES [dbo].[Guest] ([GuestID])
GO
ALTER TABLE [dbo].[GuestEventJunction] CHECK CONSTRAINT [FK_GuestEventJunction_Guest]
GO
ALTER TABLE [dbo].[GuestEventJunction]  WITH CHECK ADD  CONSTRAINT [FK_GuestEventJunction_Replies] FOREIGN KEY([RepliesID])
REFERENCES [dbo].[Replies] ([RepliesID])
GO
ALTER TABLE [dbo].[GuestEventJunction] CHECK CONSTRAINT [FK_GuestEventJunction_Replies]
GO
USE [master]
GO
ALTER DATABASE [RSVP] SET  READ_WRITE 
GO
