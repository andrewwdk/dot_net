select CustomerID, ShipCountry,(UnitPrice * Quantity * (1-Discount)) as OrderPrice from Orders
	join [Order Details] on orders.OrderID = [Order Details].OrderID
	where orders.ShipCountry in ('Brazil', 'Argentina', 'Venezuela') and orders.RequiredDate >= '1997-09-01'
	order by OrderPrice DESC
	offset 0 rows
	fetch next 3 rows only;