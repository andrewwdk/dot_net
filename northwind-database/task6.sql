select ContactName from Customers
	where charindex('171', Phone) > 0 and charindex('171', Fax) > 0 and charindex('77', Phone) > 0 and Fax like '%' + '50';