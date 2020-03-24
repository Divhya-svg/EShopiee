CREATE PROCEDURE [dbo].[ViewProductById]
	@ProductId int
AS
	SELECT * from [dbo].[Product] where ProductId=@ProductId
RETURN 0
