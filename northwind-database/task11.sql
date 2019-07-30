select EmployeeId from Employees
	order by HireDate DESC
	offset 1 row
	fetch next 1 row only;