CREATE TABLE [dbo].[UserRoles]
(
	[RoleId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoleDescription] VARCHAR(20) NOT NULL, 
    [RoleNumber] INT NOT NULL, 
    [CreatedDate] DATE NOT NULL, 
    [ModifiedDate] DATE NOT NULL, 
    [RoleIsActive] BIT NULL,
)
