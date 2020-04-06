CREATE PROCEDURE [dbo].[ViewUsers]
	@RoleNumber int
AS
	SELECT UserRoles.RoleId,Users.UserId,Users.Name,Users.MobileNumber,Users.DateOfBirth,Users.Gender,Users.EmailId,Users.Password,
	Users.CreatedDate,Users.ModifiedDate,Users.UserIsActive,userAddress.Address1,userAddress.Address2,
	UserAddress.City,UserAddress.State,UserAddress.PinCode,UserRoles.RoleDescription,UserRoles.RoleNumber,
	UserRoles.RoleIsActive from [dbo].[UserAddress] userAddress 
	INNER JOIN  [dbo].[Users] users on userAddress.UserId=users.UserId
	INNER JOIN [dbo].[UserRoles] userRoles on users.RoleId=userRoles.RoleId
	where RoleNumber=@RoleNumber
RETURN 
