CREATE VIEW CardDeckView AS (

	SELECT
		c.Id, c.CardId, c.DeckId, c.NbCard,
		d.Name as DeckName, d.UserId,
		u.FirstName, u.LastName,
		ca.Name as CardName, ca.ColorId, ca.Cost, ca.[Description], ca.PS, ca.RarityId, ca.SousTypeCardId, ca.TypeCardId,
		co.Name as ColorName,
		r.Name as RarityName,
		t.Name as TypeName,
		s.Name as SousTypeName
	
	FROM CardInDeck c

	LEFT JOIN Deck d on c.DeckId = d.Id
	LEFT JOIN [User] u on d.UserId = u.Id
	LEFT JOIN [Card] ca on c.CardId = ca.Id
	LEFT JOIN Color co on ca.ColorId = co.Id
	LEFT JOIN Rarity r on ca.RarityId = r.Id
	LEFT JOIN TypeCard t on ca.TypeCardId = t.Id
	LEFT JOIN SousTypeCard s on ca.SousTypeCardId = s.Id
);