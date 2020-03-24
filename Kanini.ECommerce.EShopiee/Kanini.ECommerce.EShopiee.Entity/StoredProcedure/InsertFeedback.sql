CREATE PROCEDURE [dbo].[InsertFeedback]
	@ProductId int,
	@UserId int,
	@Feedback varchar(MAX),
	@Rating decimal(2,1)
AS
	INSERT into [dbo].[Feedback] values(@ProductId,@UserId,@Feedback,@Rating)
RETURN 
