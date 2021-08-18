CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(200) NOT NULL, 
    [Password] VARBINARY(64) NOT NULL, 
    [BirthDate] DATETIME2 NULL, 
    [RoleId] INT NOT NULL, 
    [Salt] VARCHAR(100) NOT NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id])
)
