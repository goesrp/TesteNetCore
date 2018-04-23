

CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryName] CHAR(20) NULL
)

CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(200) NULL, 
    [CategoryID] INT NOT NULL, 
    CONSTRAINT [FK_ItemCategory] FOREIGN KEY (CategoryID) REFERENCES [Category]([Id])
)

INSERT INTO CATEGORY (CategoryName) VALUES ('Categoria 01')
INSERT INTO CATEGORY (CategoryName) VALUES ('Categoria 02')
INSERT INTO CATEGORY (CategoryName) VALUES ('Categoria 03')
