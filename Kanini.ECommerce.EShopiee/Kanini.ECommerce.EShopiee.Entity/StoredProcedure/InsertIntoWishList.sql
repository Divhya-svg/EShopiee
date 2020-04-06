CREATE PROCEDURE [dbo].[InsertIntoWishList]
	@UserId int,
	@ProductId int,
	@DateofCartAdd datetime
AS
	INSERT into [dbo].[WishList] values(
	@UserId,
	@ProductId,
	GETDATE())
RETURN 
