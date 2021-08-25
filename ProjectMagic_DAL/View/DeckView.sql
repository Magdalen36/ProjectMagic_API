CREATE VIEW DeckView AS (

	SELECT
		d.Id, d.Name as DeckName, d.UserId,
		u.FirstName, u.LastName
	
	FROM Deck d

	LEFT JOIN [User] u on d.UserId = u.Id
);