SELECT CompanyName, min(UnitPrice) as MinPrice, max(UnitPrice) as MaxPrice FROM Products
	INNER JOIN Suppliers  ON Products.SupplierID = Suppliers.SupplierID
	group by CompanyName
	order by CompanyName;