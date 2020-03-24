CREATE TABLE [dbo].[WishList]
(
	[CartId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [DateOfCartAdd] DATE NOT NULL, 
    CONSTRAINT [FK_WishList_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_WishList_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId])
)
