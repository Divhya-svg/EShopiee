CREATE PROCEDURE [dbo].[InsertPayments]
	@PaymentTypeId int,
	@CardNumber varchar(30),
	@ExpiryDate date,
	@CVV int,
	@Amount decimal(20,2),
	@DateOfPayment date

AS
	insert into [dbo].[PaymentDetails] values(@PaymentTypeId,@CardNumber,
	@ExpiryDate,@CVV,@Amount,GETDATE())
	
RETURN 
