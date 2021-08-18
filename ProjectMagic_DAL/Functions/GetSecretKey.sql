CREATE FUNCTION [dbo].[GetSecretKey]()

RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @key VARCHAR(50);

	SET @key = '1234azar§à""co/aQP(KVopm)àçé\<34/*+;,o/&noepPOD40';

	RETURN @key;

END