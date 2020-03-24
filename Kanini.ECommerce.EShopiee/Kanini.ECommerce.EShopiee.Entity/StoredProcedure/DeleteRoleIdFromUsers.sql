CREATE PROCEDURE [dbo].[DeleteRoleIdFromUsers]
	@RoleId int
AS
	DELETE from [dbo].[Users] where RoleId=@RoleId
RETURN 0
