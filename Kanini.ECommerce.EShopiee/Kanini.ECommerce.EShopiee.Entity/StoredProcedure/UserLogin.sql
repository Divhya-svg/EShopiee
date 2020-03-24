CREATE PROCEDURE [dbo].[UserLogin]
	@EmailId varchar(30),
	@MobileNumber varchar(15),
	@Password varchar(20)
AS
	SELECT * from [dbo].[Users] where EmailId=@EmailId
	AND Password=@Password OR
	MobileNumber=@MobileNumber
	AND Password=@Password
RETURN 0
