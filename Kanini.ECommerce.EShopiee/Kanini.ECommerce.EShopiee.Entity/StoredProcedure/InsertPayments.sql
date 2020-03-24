CREATE PROCEDURE [dbo].[InsertPayments]
	@PaymentTypeId int,
	@CardNumber varchar(16),
	@ExpiryDate date,
	@CVV int,
	@Amount decimal(18,2),
	@DateOfPayment date

AS
	IF @PaymentTypeId=1

	BEGIN
	insert into [dbo].[PaymentDetails] values(@CardNumber,
	@PaymentTypeId,@ExpiryDate,@CVV,@Amount,GETDATE())
	END

	IF @PaymentTypeId=2

	BEGIN
	insert into [dbo].[PaymentDetails] values(@CardNumber,
	@PaymentTypeId,@ExpiryDate,@CVV,@Amount,GETDATE())
	END

	IF @PaymentTypeId=3

	BEGIN
	insert into [dbo].PaymentDetails values('','','','',@Amount,GETDATE())
	END
RETURN 
