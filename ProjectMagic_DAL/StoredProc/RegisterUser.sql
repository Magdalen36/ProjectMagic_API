CREATE PROCEDURE [dbo].[RegisterUser](
	@Email NVARCHAR(200),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Password NVARCHAR(50),
	@RoleId INT,
	@BirthDate DATETIME2(7) )

AS 
BEGIN
	SET NOCOUNT ON;

	-- Génération du salt
	DECLARE @Salt NVARCHAR(100);
	SET @Salt = CONCAT(NEWID(), NEWID(), NEWID());

	-- Récuperation de la clé
	DECLARE @Secret NVARCHAR(50);
	SET @Secret = [dbo].[GetSecretKey]();

	-- Hashage le mot de passe
	DECLARE @Password_hash VARBINARY(64);
	SET @Password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Secret, @Salt));

	-- Insertion dans la table UserApp
	INSERT INTO [dbo].[User] (Email, FirstName, LastName, BirthDate, [Password], Salt, RoleId)
	OUTPUT [inserted].[Id]
	VALUES (@Email, @FirstName, @LastName, @BirthDate, @Password_hash, @Salt, 2)

END