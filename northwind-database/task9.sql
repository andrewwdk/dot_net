select CustomerId, round(avg(Freight), 0) as FreightAvg from Orders
	where ShipCountry = 'Canada' or ShipCountry = 'UK'
	group by CustomerId
	having round(avg(Freight), 0) < 10 or round(avg(Freight), 0) > 100
	order by FreightAvg DESC;