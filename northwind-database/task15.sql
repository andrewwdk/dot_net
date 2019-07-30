select c.CompanyName as Customer, (e.FirstName + ' ' + e.LastName) as Employee from Customers as c
	join Orders as o on o.CustomerID = c.CustomerID
	join Employees as e on o.EmployeeId = e.EmployeeId
	join Shippers as s on o.ShipVia = s.ShipperId
	where e.City = 'London' and c.City = 'London' and s.CompanyName = 'Speedy Express'
	