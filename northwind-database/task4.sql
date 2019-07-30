select CompanyName from Customers
	where City = 'Berlin' or City = 'London' or City = 'Madrid' or City = 'Paris' or City = 'Brussel'
	order by CustomerId DESC;