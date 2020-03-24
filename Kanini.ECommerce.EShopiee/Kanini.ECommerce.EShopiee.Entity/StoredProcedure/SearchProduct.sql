CREATE PROCEDURE [dbo].[SearchProduct]
	@ProductName varchar(30)
AS
	SELECT * from [dbo].[Product] where [Name ] like '%' 
	+@ProductName+ '%'
RETURN 
