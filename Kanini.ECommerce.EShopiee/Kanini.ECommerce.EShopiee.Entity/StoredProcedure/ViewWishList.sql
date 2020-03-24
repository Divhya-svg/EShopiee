CREATE PROCEDURE [dbo].[ViewWishList]
	@UserId int
AS
	SELECT * from [dbo].[Product] product 
	INNER JOIN [dbo].[WishList] wishList on product.ProductId=wishList.ProductId
where UserId=@UserId
RETURN 0
