CREATE TABLE [dbo].[CardInDeck]
(
	[Id] INT NOT NULL IDENTITY, 
    [DeckId] INT NOT NULL, 
    [CardId] INT NOT NULL, 
    [NbCard] INT NOT NULL, 
    CONSTRAINT [PK_CardInDeck] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_CardInDeck_To_Deck] FOREIGN KEY ([DeckId]) REFERENCES [Deck]([Id]), 
    CONSTRAINT [FK_CardInDeck_To_Card] FOREIGN KEY ([CardId]) REFERENCES [Card]([Id])
)
