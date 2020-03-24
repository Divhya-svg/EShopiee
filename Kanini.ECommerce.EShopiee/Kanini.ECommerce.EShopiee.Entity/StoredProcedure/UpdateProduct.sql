CREATE PROCEDURE [dbo].[UpdateProduct]
	@Name varchar(30),
	@Rating decimal(2,1),
	@ManufactureDate date,
	@CartDescription varchar(100),
	@ShortDescription varchar(MAX),
	@Image varchar(100),
	@MRP decimal(18,2),
	@DealPrice decimal(18,2),
	@SavePrice decimal(10,2),
	@NoOfStock int
AS
	update [dbo].[Product] set 
	[Name ]=@Name,
	[Rating]=@Rating,
	[ManufactureDate]=@ManufactureDate,
	[CartDescription]=@CartDescription,
	[ShortDescription]=@ShortDescription,
	[Image]=@Image,
	[MRP]=@MRP,
	[DealPrice]=@DealPrice,
	[SavePrice]=@SavePrice,
	[NoOfStock]=@NoOfStock
RETURN 
