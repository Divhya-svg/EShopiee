CREATE TABLE [dbo].[Feedback]
(
	[FeedbackId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Feedback] VARCHAR(MAX) NOT NULL, 
    [Rating] DECIMAL(2, 1) NOT NULL, 
    CONSTRAINT [FK_Feedback_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId]), 
    CONSTRAINT [FK_Feedback_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
)
