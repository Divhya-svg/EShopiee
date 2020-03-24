CREATE PROCEDURE [dbo].[AddProduct]
	@Name varchar(30),
	@Rating decimal(2,1),
	@ManufactureDate date,
	@CartDescription varchar(100),
	@ShortDescription varchar(MAX),
	@Image varchar(100),
	@MRP decimal(18,2),
	@DealPrice decimal(18,2),
	@SavePrice decimal(10,2),
	@NoOfStock int,
	@ProductIsActive bit
	
AS
	INSERT into [dbo].[Product] values(@Name,@Rating,@ManufactureDate,@CartDescription,@ShortDescription,
	@Image,@MRP,@DealPrice,@SavePrice,@NoOfStock,@ProductIsActive)
RETURN 
