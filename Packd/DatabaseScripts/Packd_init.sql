-- Use master
USE [master];
GO

-- Drop database if exists
IF DATABASEPROPERTYEX ('Packd', 'Version') IS NOT NULL
BEGIN 
	ALTER Database [Packd] SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [Packd];
END
GO

-- Create Packd database
CREATE DATABASE [Packd];
GO

-- Set recovery to SIMPLE
ALTER DATABASE [Packd] SET RECOVERY SIMPLE;
GO

-- Use the Packd database
USE [Packd];
GO

-- Create Items schema
CREATE SCHEMA [Packd];
GO


-- Create tables: Category, Item, List.

-- Create table : Category
CREATE TABLE [Packd].[Category](
	[Id] int identity (1,1) NOT NULL,
	[Name] nvarchar(500) NOT NULL,
	[CreationDate] datetime NOT NULL DEFAULT GETDATE(),
	[IsDefault] int NOT NULL DEFAULT 0
	
	CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

-- Populate Category table with the default values
INSERT INTO [Packd].[Category] (Name, IsDefault)
VALUES 
	('Documents', 1),
	('Clothes', 1),
	('Electronics', 1),
	('Food', 1),
	('Other', 1)
;
GO


-- Create table: Items
CREATE TABLE [Packd].[Items](
	[Id] int identity (1,1) NOT NULL,
	[Name] nvarchar(500) NOT NULL,
	[CreationDate] datetime NOT NULL DEFAULT GETDATE(),
	[IsDefault] int NOT NULL DEFAULT 0,
	[CategoryId] int NOT NULL
	
	CONSTRAINT [PK_Items] PRIMARY KEY ([Id])
	CONSTRAINT [FK_CategoryId] FOREIGN KEY ([CategoryId])  REFERENCES [Packd].[Category] ([Id]) ON DELETE CASCADE
);
GO

-- Populate Items table with the default values
INSERT INTO [Packd].[Items] (Name, IsDefault, CategoryId)
VALUES 
	
	-- Documents
	('Passport', 1, 1),
	('Tickets', 1, 1),
	('Id Cards', 1, 1),
	('Visa', 1, 1),
	('Debit Card', 1, 1),
	('Credit Card', 1, 1),
	('Insurance Documents', 1, 1),
	
	-- Clothes
	('T-Shits', 1, 2),
	('Shirts', 1, 2),
	('Shorts', 1, 2),
	('Pants', 1, 2),
	('Gloves', 1, 2),
	('Belt', 1, 2),
	('Hat', 1, 2),
	('Underwear', 1, 2),
	('Shoes', 1, 2),
	('Jacket', 1, 2),
	('Coat', 1, 2),
	('Socks', 1, 2),

	-- Electronics
	('Laptop + charger', 1, 3),
	('Mobile phone + charger', 1, 3),
	('Speakers', 1, 3),
	('Headphones/Earplugs', 1, 3),
	('GPS', 1, 3),

	-- Food
	('Water', 1, 4),
	('Sandwiches', 1, 4),
	('Protein bars', 1, 4),

	-- Other
	('Cigarettes', 1, 5),
	('Lighter', 1, 5),
	('Medicine', 1, 5),
	('Gum', 1, 5)
;
GO

-- Create table : Lists
CREATE TABLE [Packd].[Lists](
	[Id] int identity (1,1) NOT NULL,
	[Name] nvarchar(500) NOT NULL,
	[CreationDate] datetime NOT NULL DEFAULT GETDATE()
	
	CONSTRAINT [PK_Lists] PRIMARY KEY ([Id])
);
GO

-- Populate Lists table with the default values
INSERT INTO [Packd].[Lists] (Name)
VALUES 
	('Default')
;
GO

-- Create table : ListContent
CREATE TABLE [Packd].[ListContent](
	[Id] int identity (1,1) NOT NULL,
	[ListId] int NOT NULL,
	[CategoryId] int NOT NULL,
	[ItemId] int NOT NULL,
	[IsPacked] int NOT NULL DEFAULT 0
);
GO

-- Populate ListContent table with the default values
INSERT INTO [Packd].[ListContent] (ListId, CategoryId, ItemId)
VALUES 
	(1, 1, 1),
	(1, 1, 2),
	(1, 1, 3),
	(1, 1, 4),
	(1, 1, 5),
	(1, 1, 6),
	(1, 1, 7),

	(1, 2, 8),
	(1, 2, 9),
	(1, 2, 10),
	(1, 2, 11),
	(1, 2, 12),
	(1, 2, 13),
	(1, 2, 14),
	(1, 2, 15),
	(1, 2, 16),
	(1, 2, 17),
	(1, 2, 18),
	(1, 2, 19),

	(1, 3, 20),
	(1, 3, 21),
	(1, 3, 22),
	(1, 3, 23),
	(1, 3, 24),

	(1, 4, 25),
	(1, 4, 26),
	(1, 4, 27),

	(1, 5, 28),
	(1, 5, 29),
	(1, 5, 30),
	(1, 5, 31)
;
GO

-- Declare Stored Procedures
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create New List Stored Procedure
CREATE OR ALTER PROCEDURE [Packd].[CreateNewList_StoredProcedure]
@Name varchar(500)
AS
BEGIN
	INSERT INTO Packd.Lists (Name, CreationDate) VALUES (@Name, GETDATE())
END
GO

-- Create New Category Stored Procedure
CREATE OR ALTER PROCEDURE [Packd].[CreateNewCategory_StoredProcedure]
@Name varchar(500)
AS
BEGIN
	INSERT INTO Packd.Category(Name, CreationDate, IsDefault) VALUES (@Name, GETDATE(), 0)
END
GO

-- Create New Item Stored Procedure
CREATE OR ALTER PROCEDURE [Packd].[CreateNewItem_StoredProcedure]
@Name varchar(500),
@CategoryId int
AS
BEGIN
	INSERT INTO Packd.Items(Name, CreationDate, IsDefault, CategoryId) VALUES (@Name, GETDATE(), 0, @CategoryId)
END
GO

-- Create New List Content Stored Procedure
CREATE OR ALTER PROCEDURE [Packd].[CreateNewListContent_StoredProcedure]
@ListId int,
@CategoryId int,
@ItemId int
AS
BEGIN
	INSERT INTO Packd.ListContent(ListId, CategoryId, ItemId) VALUES (@ListId, @CategoryId, @ItemId)
END
GO

-- Update IsPacked on Item in ListContent Stored Procedure
CREATE OR ALTER PROCEDURE [Packd].UpdateItemIsPacked_StoredProcedure
@IsPacked int,
@ListContentId int
AS
BEGIN
	UPDATE Packd.ListContent SET IsPacked = @IsPacked WHERE Id = @ListContentId
END
GO

-- Delete List Stored Procedure
CREATE OR ALTER PROCEDURE [Packd].[DeleteList_StoredProcedure]
@ListId int
AS
BEGIN
	IF (@ListId <> 1) -- default list
	BEGIN
		DELETE FROM [Packd].[Lists] WHERE Lists.Id = @ListId;
		DELETE FROM [Packd].[ListContent] WHERE ListContent.ListId = @ListId;
	END
END
GO

-- Delete List Content Information Stored Procedure
CREATE OR ALTER PROCEDURE [Packd].DeleteListContentInfo_StoredProcedure
@ListId int
AS
BEGIN
	IF (@ListId <> 1)
	BEGIN
		DELETE FROM Packd.ListContent WHERE ListId = @ListId
	END
END
GO