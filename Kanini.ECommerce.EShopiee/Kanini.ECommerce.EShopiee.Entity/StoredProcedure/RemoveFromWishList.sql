CREATE PROCEDURE [dbo].[RemoveFromWishList]
	@UserId int,
	@ProdcutId int
AS
	DELETE from [dbo].[WishList] where UserId=@UserId and 
	ProductId=@ProdcutId
RETURN 
