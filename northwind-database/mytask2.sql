/* get all orders where ShippedDate > RequiredDate*/
select OrderId, datediff(day, RequiredDate, ShippedDate) as DelayDays from Orders
	where ShippedDate > RequiredDate;