CREATE VIEW CollectionView AS ( 
	
	SELECT 

		co.Id,
		co.UserId,
		co.CardId,
		co.NbCard,
		u.FirstName,
		u.LastName,
		c.Name as CardName,
		c.ColorId,
		c.EditionId,
		e.Name as EditionName,
		col.Name as ColorName

	FROM Collection co

	LEFT JOIN [User] u ON co.UserId = u.Id
	LEFT JOIN [Card] c ON co.CardId = c.Id
	LEFT JOIN Edition e ON e.Id = c.EditionId
	LEFT JOIN Color col ON col.Id = c.ColorId

);