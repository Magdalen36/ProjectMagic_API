CREATE PROCEDURE [dbo].[LoginUser]
	(@Email NVARCHAR(200),
	@Password NVARCHAR(50))
AS
BEGIN
	DECLARE @Salt NVARCHAR(100);
	SELECT @Salt = Salt FROM [dbo].[User] WHERE Email = @Email

	IF @Salt IS NOT NULL
	BEGIN
		DECLARE @Secret NVARCHAR(50);
		SET @Secret = [dbo].[GetSecretKey]();

		DECLARE @Password_hash VARBINARY(64);
		SET @Password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Secret, @Salt));

		DECLARE @UserId INT;
		SELECT @UserId = [Id] FROM [User] WHERE [Email] = @Email AND [Password] = @Password_hash;

		SELECT * FROM [User] WHERE Id = @UserId
	END
END
