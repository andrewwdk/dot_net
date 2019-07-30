select CustomerId from Orders
	where RequiredDate >= '1996-09-01' and RequiredDate <= '1996-09-30'
	order by CustomerId;