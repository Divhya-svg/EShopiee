CREATE PROCEDURE [dbo].[DeleteRoleIdFromUserRoles]
	@RoleId int
AS
	DELETE from [dbo].[UserRoles] where RoleId=@RoleId
RETURN 0
