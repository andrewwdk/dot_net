select p.ProductName, p.UnitsInStock, s.ContactName, s.Phone from Products as p
	join Categories as c on p.CategoryID = c.CategoryID
	join Suppliers as s on p.SupplierID = s.SupplierID
	where p.Discontinued = 'false' and p.UnitsInStock < 20 and c.CategoryName in ('Beverages', 'Seafood')
	order by p.UnitsInStock;