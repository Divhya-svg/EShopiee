CREATE PROCEDURE [dbo].[DeleteUserIdFromUserAddress]
	@RoleId int
AS
	DELETE from [dbo].[UserAddress] where UserId in(select UserId
	from [dbo].[Users] where RoleId=@RoleId)
RETURN 
