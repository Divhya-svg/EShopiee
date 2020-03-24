CREATE PROCEDURE [dbo].[InsertIntoWishList]
	@UserId int,
	@ProductId int,
	@DateofCartAdd int
AS
	INSERT into [dbo].[WishList] values(
	@UserId,
	@ProductId,
	GETDATE())
RETURN 
