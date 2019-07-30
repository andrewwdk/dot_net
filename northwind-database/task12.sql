select CustomerId, sum(Freight) as FreightSum from Orders
	where Freight >= (select avg(Freight) as AverageFreight from Orders) and ShippedDate >= '1996-07-16' and ShippedDate <= '1996-07-31'
	group by CustomerId
	order by FreightSum;
