/* get countries and count of delays*/
select ShipCountry, count(*) as DelayCount from Orders
	where ShippedDate > RequiredDate
	group by ShipCountry
	order by DelayCount DESC;