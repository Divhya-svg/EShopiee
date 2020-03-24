CREATE PROCEDURE [dbo].[InsertUserRoles]
	@RoleDescription varchar(20),
	@RoleNumber int,
	@CreatedDate date,
	@ModifiedDate date,
	@RoleIsActive bit
AS
	INSERT into [dbo].[UserRoles] values (@RoleDescription,@RoleNumber,GETDATE(),
	Getdate(),@RoleIsActive)
RETURN 0
