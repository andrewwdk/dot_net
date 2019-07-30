select City, count(*) as CustomerCount from Customers
	where Country = 'Denmark' or Country = 'Sweden' or Country = 'Norway'
	group by City;