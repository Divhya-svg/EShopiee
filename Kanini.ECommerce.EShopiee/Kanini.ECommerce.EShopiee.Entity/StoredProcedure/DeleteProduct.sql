CREATE PROCEDURE [dbo].[DeleteProduct]
	@ProductId int
AS
	DELETE from [dbo].[Product] where ProductId=@ProductId
RETURN 
