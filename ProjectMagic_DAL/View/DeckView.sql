CREATE VIEW DeckView AS (

	SELECT
		d.Id, d.Name as DeckName, d.UserId, d.ColorId,
		u.FirstName, u.LastName,
		c.Name as ColorName
	
	FROM Deck d

	LEFT JOIN [User] u on d.UserId = u.Id
	LEFT JOIN [Color] c on d.ColorId = c.Id
);