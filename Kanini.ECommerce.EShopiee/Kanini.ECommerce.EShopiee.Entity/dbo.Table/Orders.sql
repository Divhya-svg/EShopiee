CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [PaymentId] INT NOT NULL, 
    
    [OrderDate] DATE NOT NULL, 
    CONSTRAINT [FK_Orders_OrderDetails] FOREIGN KEY ([OrderId]) REFERENCES [OrderDetails]([OrderId]), 
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Orders_PaymentDetails] FOREIGN KEY ([PaymentId]) REFERENCES [PaymentDetails]([PaymentId]) 
)
