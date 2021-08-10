CREATE TABLE [dbo].[Card]
(
	[Id] INT NOT NULL IDENTITY, 
    [EditionId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [DesignCard] VARCHAR(MAX) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [RarityId] INT NOT NULL, 
    [PS] VARCHAR(50) NULL, 
    [Premium] BIT NOT NULL DEFAULT 0, 
    [TypeCardId] INT NOT NULL, 
    [SousTypeCardId] INT NULL, 
    [Cost] VARCHAR(50) NULL, 
    [ColorId] INT NOT NULL, 
    CONSTRAINT [PK_Card] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Card_To_Edition] FOREIGN KEY ([EditionId]) REFERENCES [Edition]([Id]), 
    CONSTRAINT [FK_Card_To_TypeCard] FOREIGN KEY ([TypeCardId]) REFERENCES [TypeCard]([Id]), 
    CONSTRAINT [FK_Card_To_SousTypeCard] FOREIGN KEY ([SousTypeCardId]) REFERENCES [SousTypeCard]([Id]), 
    CONSTRAINT [FK_Card_To_Rarity] FOREIGN KEY ([RarityId]) REFERENCES [Rarity]([Id]),
    CONSTRAINT [FK_Card_To_Color] FOREIGN KEY ([ColorId]) REFERENCES [Color]([Id])
)


