CREATE PROCEDURE [dbo].[InsertPaymentType]
	@PaymentType varchar(20)
AS
	INSERT into [dbo].[PaymentType] values(@PaymentType)
RETURN 
