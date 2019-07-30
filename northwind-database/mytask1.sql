/* show names of companies which bought products with 10% and more discount*/
select c.CompanyName, max(od.Discount) as MaxDiscount from Orders as o
	join Customers as c on o.CustomerId = c.CustomerID
	join [Order Details] as od on o.OrderId = od.OrderID
	where od.Discount >= 0.1
	group by c.CompanyName;