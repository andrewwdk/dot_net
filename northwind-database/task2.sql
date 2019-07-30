select EmployeeID from Employees
	where HireDate = (select max(HireDate) from employees);