CREATE PROCEDURE [dbo].[ViewWishList]
	@UserId int
AS
	SELECT Product.[Name],Product.[Rating],Product.[CartDescription],Product.[ShortDescription],
	Product.[Image],Product.[MRP],Product.[DealPrice],Product.[SavePrice],Product.[NoOfStock],WishList.[DateOfCartAdd]
	from [dbo].[Product] product 
	INNER JOIN [dbo].[WishList] wishList on product.ProductId=wishList.ProductId
where UserId=@UserId
RETURN 
