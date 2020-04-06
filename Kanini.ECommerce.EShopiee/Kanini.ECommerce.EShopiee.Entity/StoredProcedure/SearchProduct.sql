CREATE PROCEDURE [dbo].[SearchProduct]
	@Name varchar(30)
AS
	SELECT * from [dbo].[Product] where Product.[Name] like '%' 
	+ @Name + '%'
RETURN 
