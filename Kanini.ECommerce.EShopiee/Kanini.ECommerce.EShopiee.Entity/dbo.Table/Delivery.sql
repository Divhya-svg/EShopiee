CREATE TABLE [dbo].[Delivery]
(
	[DeliveryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [OrderId] INT NOT NULL, 
    [DeliveryStatus] VARCHAR(20) NOT NULL, 
    [DeliveryDate] DATE NOT NULL, 
    CONSTRAINT [FK_Delivery_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId]), 
    CONSTRAINT [FK_Delivery_OrderDetails] FOREIGN KEY ([OrderId]) REFERENCES [OrderDetails]([OrderId])
)
