CREATE PROCEDURE [dbo].[GetByPaymentTypeId]
	@PaymentType varchar(20)
AS
	SELECT PaymentTypeId from [dbo].[PaymentType]
	where PaymentType=@PaymentType

	
RETURN 
