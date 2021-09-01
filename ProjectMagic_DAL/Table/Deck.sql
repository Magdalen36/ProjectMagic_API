CREATE TABLE [dbo].[Deck]
(
	[Id] INT NOT NULL IDENTITY, 
    [UserId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL DEFAULT 'deck sans nom', 
    [ColorId] INT NOT NULL, 
    CONSTRAINT [PK_Deck] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Deck_To_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Deck_To_Color] FOREIGN KEY ([ColorId]) REFERENCES [Color]([Id])
)
