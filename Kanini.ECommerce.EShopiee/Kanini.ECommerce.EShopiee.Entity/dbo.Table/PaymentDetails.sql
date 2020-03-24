CREATE TABLE [dbo].[PaymentDetails]
(
	[PaymentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PaymentTypeId] INT NOT NULL, 
    [CardNumber] VARCHAR(16) NOT NULL, 
    [ExpiryDate] DATE NOT NULL, 
    [CVV] INT NOT NULL, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [DateOfPayment] DATE NULL, 
    CONSTRAINT [FK_PaymentDetails_PaymentMode] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentType]([PaymentTypeId]), 

    
)
