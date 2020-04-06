CREATE PROCEDURE [dbo].[DeleteRoleIdFromUsers]
	@RoleId int
AS
	
	delete from [dbo].[Users] where RoleId=@RoleId
RETURN 
