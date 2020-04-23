
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2020 13:57:26
-- Generated from EDMX file: F:\Career Research\Lauren\RSVP\Infrastucture\Data\RSVP.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RSVP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Guest_GuestGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Guest] DROP CONSTRAINT [FK_Guest_GuestGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_GuestEventJunction_Events]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuestEventJunction] DROP CONSTRAINT [FK_GuestEventJunction_Events];
GO
IF OBJECT_ID(N'[dbo].[FK_GuestEventJunction_Guest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuestEventJunction] DROP CONSTRAINT [FK_GuestEventJunction_Guest];
GO
IF OBJECT_ID(N'[dbo].[FK_GuestEventJunction_Replies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuestEventJunction] DROP CONSTRAINT [FK_GuestEventJunction_Replies];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Guest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Guest];
GO
IF OBJECT_ID(N'[dbo].[GuestEventJunction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GuestEventJunction];
GO
IF OBJECT_ID(N'[dbo].[GuestGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GuestGroup];
GO
IF OBJECT_ID(N'[dbo].[Replies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Replies];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventID] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(50)  NOT NULL,
    [Subtitle] varchar(100)  NULL,
    [Description] varchar(300)  NULL,
    [EventStartDate] datetime  NOT NULL,
    [EventEndDate] datetime  NOT NULL,
    [Venue] varchar(50)  NOT NULL,
    [Address] varchar(100)  NOT NULL,
    [EventStartTime] time  NOT NULL,
    [EventEndTime] time  NOT NULL,
    [Details] varchar(300)  NULL
);
GO

-- Creating table 'Guests'
CREATE TABLE [dbo].[Guests] (
    [GuestID] int IDENTITY(1,1) NOT NULL,
    [GuestGroupID] int  NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [IsChild] bit  NOT NULL
);
GO

-- Creating table 'GuestEventJunctions'
CREATE TABLE [dbo].[GuestEventJunctions] (
    [GuestID] int  NOT NULL,
    [EventID] int  NOT NULL,
    [RepliesID] int  NULL
);
GO

-- Creating table 'GuestGroups'
CREATE TABLE [dbo].[GuestGroups] (
    [GuestGroupID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NOT NULL
);
GO

-- Creating table 'Replies'
CREATE TABLE [dbo].[Replies] (
    [RepliesID] int IDENTITY(1,1) NOT NULL,
    [Attending] bit  NULL,
    [AtendeeEmail] varchar(50)  NOT NULL,
    [MealSelection] varchar(100)  NULL,
    [Notes] varchar(400)  NULL,
    [NeedParking] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EventID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventID] ASC);
GO

-- Creating primary key on [GuestID] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [PK_Guests]
    PRIMARY KEY CLUSTERED ([GuestID] ASC);
GO

-- Creating primary key on [GuestID], [EventID] in table 'GuestEventJunctions'
ALTER TABLE [dbo].[GuestEventJunctions]
ADD CONSTRAINT [PK_GuestEventJunctions]
    PRIMARY KEY CLUSTERED ([GuestID], [EventID] ASC);
GO

-- Creating primary key on [GuestGroupID] in table 'GuestGroups'
ALTER TABLE [dbo].[GuestGroups]
ADD CONSTRAINT [PK_GuestGroups]
    PRIMARY KEY CLUSTERED ([GuestGroupID] ASC);
GO

-- Creating primary key on [RepliesID] in table 'Replies'
ALTER TABLE [dbo].[Replies]
ADD CONSTRAINT [PK_Replies]
    PRIMARY KEY CLUSTERED ([RepliesID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EventID] in table 'GuestEventJunctions'
ALTER TABLE [dbo].[GuestEventJunctions]
ADD CONSTRAINT [FK_GuestEventJunction_Events]
    FOREIGN KEY ([EventID])
    REFERENCES [dbo].[Events]
        ([EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GuestEventJunction_Events'
CREATE INDEX [IX_FK_GuestEventJunction_Events]
ON [dbo].[GuestEventJunctions]
    ([EventID]);
GO

-- Creating foreign key on [GuestGroupID] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [FK_Guest_GuestGroup]
    FOREIGN KEY ([GuestGroupID])
    REFERENCES [dbo].[GuestGroups]
        ([GuestGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Guest_GuestGroup'
CREATE INDEX [IX_FK_Guest_GuestGroup]
ON [dbo].[Guests]
    ([GuestGroupID]);
GO

-- Creating foreign key on [GuestID] in table 'GuestEventJunctions'
ALTER TABLE [dbo].[GuestEventJunctions]
ADD CONSTRAINT [FK_GuestEventJunction_Guest]
    FOREIGN KEY ([GuestID])
    REFERENCES [dbo].[Guests]
        ([GuestID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RepliesID] in table 'GuestEventJunctions'
ALTER TABLE [dbo].[GuestEventJunctions]
ADD CONSTRAINT [FK_GuestEventJunction_Replies]
    FOREIGN KEY ([RepliesID])
    REFERENCES [dbo].[Replies]
        ([RepliesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GuestEventJunction_Replies'
CREATE INDEX [IX_FK_GuestEventJunction_Replies]
ON [dbo].[GuestEventJunctions]
    ([RepliesID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------