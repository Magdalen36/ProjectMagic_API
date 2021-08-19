CREATE VIEW CardView AS (

	SELECT 
		c.Id,
		c.Name as CardName,
		c.Cost, 
		c.PS,
		c.Premium,
		c.Description,
		c.EditionId,
		c.RarityId,
		c.TypeCardId,
		c.SousTypeCardId,
		c.ColorId,
		
		e.Name as EditionName,
		r.Name as RarityName, 
		t.Name as TypeCardName,
		s.Name as SousTypeCardName,
		co.Name as ColorName
	
	FROM Card c 

	LEFT JOIN Edition e ON c.EditionId = e.Id
	LEFT JOIN Rarity r ON c.RarityId=r.Id
	LEFT JOIN TypeCard t ON c.TypeCardId=t.Id
	LEFT JOIN SousTypeCard s ON c.SousTypeCardId=s.Id
	LEFT JOIN Color co ON c.ColorId=co.Id

);