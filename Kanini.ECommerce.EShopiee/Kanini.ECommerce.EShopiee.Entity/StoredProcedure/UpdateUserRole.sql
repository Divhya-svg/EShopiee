CREATE PROCEDURE [dbo].[UpdateUserRole]
	@RoleId int,
	@RoleDescription varchar(20),
	@RoleNumber int,
	@RoleIsActive bit
AS
	UPDATE [dbo].[UserRoles] set 
	RoleDescription=@RoleDescription,
	RoleNumber=@RoleNumber,
	ModifiedDate=GETDATE(),
	RoleIsActive=@RoleIsActive where RoleId=@RoleId
RETURN 
