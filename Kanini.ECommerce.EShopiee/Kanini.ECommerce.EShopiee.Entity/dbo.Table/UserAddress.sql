CREATE TABLE [dbo].[UserAddress]
(
	[UserId] INT NOT NULL , 
    [Address1] VARCHAR(100) NOT NULL, 
    [Address2] VARCHAR(100) NOT NULL, 
    [City] VARCHAR(20) NOT NULL, 
    [State] VARCHAR(30) NOT NULL, 
    [PinCode] VARCHAR(20) NOT NULL, 
    CONSTRAINT [FK_UserAddress_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
