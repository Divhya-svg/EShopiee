CREATE PROCEDURE [dbo].[ViewOrderList]

AS
BEGIN
	SELECT p.[Name],p.[CartDescription],o.[Price],
	o.[Quantity] from [dbo].[Product] p INNER JOIN
	[dbo].[OrderDetails] o on p.ProductId=o.ProductId
	

END
