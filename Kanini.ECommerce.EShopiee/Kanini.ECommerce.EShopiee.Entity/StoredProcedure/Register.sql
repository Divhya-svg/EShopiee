CREATE PROCEDURE [dbo].[Register]
	@Name varchar(30),
	@RoleId int,
	@MobileNumber varchar(15),
	@DateOfBirth date,
	@Gender varchar(10),
	@EmailId varchar(30),
	@Password varchar(20),
	@CreatedDate date,
	@ModifiedDate date,
	@UserIsActive bit
AS
	INSERT into [dbo].[Users] values(@Name,@RoleId,@MobileNumber,@DateOfBirth,@Gender,
	@EmailId,@Password,GETDATE(),GETDATE(),@UserIsActive)
RETURN 0
