CREATE TABLE [dbo].[Collection]
(
	[Id] INT NOT NULL IDENTITY, 
    [UserId] INT NOT NULL, 
    [CardId] INT NOT NULL, 
    [NbCard] INT NOT NULL, 
    CONSTRAINT [PK_Collection] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Collection_To_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Collection_To_Card] FOREIGN KEY ([CardId]) REFERENCES [Card]([Id])
)
