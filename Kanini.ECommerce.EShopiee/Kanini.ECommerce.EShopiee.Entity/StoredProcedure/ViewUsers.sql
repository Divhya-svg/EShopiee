CREATE PROCEDURE [dbo].[ViewUsers]
	@RoleNumber int
AS
	SELECT * from [dbo].[UserAddress] userAddress 
	INNER JOIN [dbo].[Users] users on userAddress.UserId=users.UserId
	INNER JOIN [dbo].[UserRoles] userRoles on users.RoleId=userRoles.RoleId
	where RoleNumber=@RoleNumber
RETURN 
