CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(200) NULL, 
    [CategoryID] INT NOT NULL, 
    CONSTRAINT [FK_ItemCategory] FOREIGN KEY (CategoryID) REFERENCES [Category]([Id])
)
