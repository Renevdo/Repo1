
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2014 20:22:30
-- Generated from EDMX file: C:\Users\reneo\documents\visual studio 2012\Projects\ETTU Gadgets\ETTU Gadgets Web\Models\DragonModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DragonDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonBoat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet] DROP CONSTRAINT [FK_PersonBoat];
GO
IF OBJECT_ID(N'[dbo].[FK_RaceResultRace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceResultSet] DROP CONSTRAINT [FK_RaceResultRace];
GO
IF OBJECT_ID(N'[dbo].[FK_BoatRaceResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceResultSet] DROP CONSTRAINT [FK_BoatRaceResult];
GO
IF OBJECT_ID(N'[dbo].[FK_RaceImageBoat_RaceImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceImageBoat] DROP CONSTRAINT [FK_RaceImageBoat_RaceImage];
GO
IF OBJECT_ID(N'[dbo].[FK_RaceImageBoat_Boat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceImageBoat] DROP CONSTRAINT [FK_RaceImageBoat_Boat];
GO
IF OBJECT_ID(N'[dbo].[FK_RaceImagePerson_RaceImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceImagePerson] DROP CONSTRAINT [FK_RaceImagePerson_RaceImage];
GO
IF OBJECT_ID(N'[dbo].[FK_RaceImagePerson_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceImagePerson] DROP CONSTRAINT [FK_RaceImagePerson_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BoatSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoatSet];
GO
IF OBJECT_ID(N'[dbo].[RaceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaceSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[RaceResultSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaceResultSet];
GO
IF OBJECT_ID(N'[dbo].[RaceImageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaceImageSet];
GO
IF OBJECT_ID(N'[dbo].[RaceImageBoat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaceImageBoat];
GO
IF OBJECT_ID(N'[dbo].[RaceImagePerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaceImagePerson];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BoatSet'
CREATE TABLE [dbo].[BoatSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RaceSet'
CREATE TABLE [dbo].[RaceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pool] nvarchar(max)  NOT NULL,
    [RaceSchemaId] int  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Boat_Id] int  NOT NULL
);
GO

-- Creating table 'RaceResultSet'
CREATE TABLE [dbo].[RaceResultSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Start] time  NOT NULL,
    [End] time  NOT NULL,
    [RaceId] int  NOT NULL,
    [BoatId] int  NOT NULL
);
GO

-- Creating table 'RaceImageSet'
CREATE TABLE [dbo].[RaceImageSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RaceSchemaSet'
CREATE TABLE [dbo].[RaceSchemaSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RaceImageBoat'
CREATE TABLE [dbo].[RaceImageBoat] (
    [RaceImages_Id] int  NOT NULL,
    [Boats_Id] int  NOT NULL
);
GO

-- Creating table 'RaceImagePerson'
CREATE TABLE [dbo].[RaceImagePerson] (
    [RaceImages_Id] int  NOT NULL,
    [Persons_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BoatSet'
ALTER TABLE [dbo].[BoatSet]
ADD CONSTRAINT [PK_BoatSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RaceSet'
ALTER TABLE [dbo].[RaceSet]
ADD CONSTRAINT [PK_RaceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RaceResultSet'
ALTER TABLE [dbo].[RaceResultSet]
ADD CONSTRAINT [PK_RaceResultSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RaceImageSet'
ALTER TABLE [dbo].[RaceImageSet]
ADD CONSTRAINT [PK_RaceImageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RaceSchemaSet'
ALTER TABLE [dbo].[RaceSchemaSet]
ADD CONSTRAINT [PK_RaceSchemaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RaceImages_Id], [Boats_Id] in table 'RaceImageBoat'
ALTER TABLE [dbo].[RaceImageBoat]
ADD CONSTRAINT [PK_RaceImageBoat]
    PRIMARY KEY NONCLUSTERED ([RaceImages_Id], [Boats_Id] ASC);
GO

-- Creating primary key on [RaceImages_Id], [Persons_Id] in table 'RaceImagePerson'
ALTER TABLE [dbo].[RaceImagePerson]
ADD CONSTRAINT [PK_RaceImagePerson]
    PRIMARY KEY NONCLUSTERED ([RaceImages_Id], [Persons_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Boat_Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [FK_PersonBoat]
    FOREIGN KEY ([Boat_Id])
    REFERENCES [dbo].[BoatSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonBoat'
CREATE INDEX [IX_FK_PersonBoat]
ON [dbo].[PersonSet]
    ([Boat_Id]);
GO

-- Creating foreign key on [RaceId] in table 'RaceResultSet'
ALTER TABLE [dbo].[RaceResultSet]
ADD CONSTRAINT [FK_RaceResultRace]
    FOREIGN KEY ([RaceId])
    REFERENCES [dbo].[RaceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RaceResultRace'
CREATE INDEX [IX_FK_RaceResultRace]
ON [dbo].[RaceResultSet]
    ([RaceId]);
GO

-- Creating foreign key on [BoatId] in table 'RaceResultSet'
ALTER TABLE [dbo].[RaceResultSet]
ADD CONSTRAINT [FK_BoatRaceResult]
    FOREIGN KEY ([BoatId])
    REFERENCES [dbo].[BoatSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BoatRaceResult'
CREATE INDEX [IX_FK_BoatRaceResult]
ON [dbo].[RaceResultSet]
    ([BoatId]);
GO

-- Creating foreign key on [RaceImages_Id] in table 'RaceImageBoat'
ALTER TABLE [dbo].[RaceImageBoat]
ADD CONSTRAINT [FK_RaceImageBoat_RaceImage]
    FOREIGN KEY ([RaceImages_Id])
    REFERENCES [dbo].[RaceImageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Boats_Id] in table 'RaceImageBoat'
ALTER TABLE [dbo].[RaceImageBoat]
ADD CONSTRAINT [FK_RaceImageBoat_Boat]
    FOREIGN KEY ([Boats_Id])
    REFERENCES [dbo].[BoatSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RaceImageBoat_Boat'
CREATE INDEX [IX_FK_RaceImageBoat_Boat]
ON [dbo].[RaceImageBoat]
    ([Boats_Id]);
GO

-- Creating foreign key on [RaceImages_Id] in table 'RaceImagePerson'
ALTER TABLE [dbo].[RaceImagePerson]
ADD CONSTRAINT [FK_RaceImagePerson_RaceImage]
    FOREIGN KEY ([RaceImages_Id])
    REFERENCES [dbo].[RaceImageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Persons_Id] in table 'RaceImagePerson'
ALTER TABLE [dbo].[RaceImagePerson]
ADD CONSTRAINT [FK_RaceImagePerson_Person]
    FOREIGN KEY ([Persons_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RaceImagePerson_Person'
CREATE INDEX [IX_FK_RaceImagePerson_Person]
ON [dbo].[RaceImagePerson]
    ([Persons_Id]);
GO

-- Creating foreign key on [RaceSchemaId] in table 'RaceSet'
ALTER TABLE [dbo].[RaceSet]
ADD CONSTRAINT [FK_RaceSchemaRace]
    FOREIGN KEY ([RaceSchemaId])
    REFERENCES [dbo].[RaceSchemaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RaceSchemaRace'
CREATE INDEX [IX_FK_RaceSchemaRace]
ON [dbo].[RaceSet]
    ([RaceSchemaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------