select Country, count(*) as CustomerCount from Customers
	group by Country
	having count(*) >= 10
	order by CustomerCount DESC;