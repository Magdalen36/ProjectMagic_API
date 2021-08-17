CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(MAX) NOT NULL, 
    [Password] VARBINARY(50) NOT NULL, 
    [BirthDate] DATETIME NULL, 
    [RoleId] INT NOT NULL, 
    [Salt] CHAR(36) NOT NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id])
)
