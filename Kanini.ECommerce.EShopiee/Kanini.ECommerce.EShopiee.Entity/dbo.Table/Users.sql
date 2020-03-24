CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoleId] INT NOT NULL, 
	[Name] VARCHAR(30) NOT NULL,
    [MobileNumber] VARCHAR(15) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Gender] VARCHAR(10) NOT NULL, 
    [EmailId] VARCHAR(30) NOT NULL UNIQUE, 
    [Password] VARCHAR(20) NOT NULL, 
    [CreatedDate] DATE NOT NULL, 
    [ModifiedDate] DATE NOT NULL, 
    [UserIsActive] BIT NOT NULL, 
    CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY ([RoleId]) REFERENCES [UserRoles]([RoleId]),
)
