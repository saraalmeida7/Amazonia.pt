CREATE PROCEDURE [dbo].[usp_ConverterNomeParaMaisculo]
	@param1 VARCHAR(50)
AS
	SELECT UPPER(@param1)
RETURN 0
