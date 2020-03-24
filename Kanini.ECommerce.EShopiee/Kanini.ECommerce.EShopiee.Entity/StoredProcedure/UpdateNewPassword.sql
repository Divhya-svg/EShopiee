CREATE PROCEDURE [dbo].[UpdateNewPassword]
	@NewPassword varchar(20),
	@EmailId varchar(30),
	@MobileNumber varchar(15),
	@UserId int
AS
	UPDATE [dbo].[Users] set Password=@NewPassword
	where UserId=@UserId and EmailId=@EmailId OR 
	MobileNumber=@MobileNumber
RETURN 0
