CREATE PROCEDURE [dbo].[UserLogin]
	@EmailId varchar(30),
	@MobileNumber varchar(15),
	@Password varchar(20)
AS
Declare @Select varchar(4000)

Set @Select='SELECT * from [dbo].[Users] where '

IF Len(@EmailId)!=0 
	BEGIN
		SET @Select = @Select + ' Emailid=''' +  @EmailId + ''''
	END
IF LEN(@MobileNumber)!=0
BEGIN
	SET @Select = @Select + ' MobileNumber=''' + @MobileNumber +''''
END
	
	
	SET @Select= @Select + ' AND  Password= ''' + @Password + ''''
	
EXEC(@Select)
	
