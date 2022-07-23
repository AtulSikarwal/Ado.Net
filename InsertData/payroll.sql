

	

	alter procedure spAddEmployee
	@Name varchar(200),
	@Address nvarchar(200),
	@Gender char(1),
	@Salary float,
	@PhoneNumber bigint
	As
	insert into employee_payroll2(Name,Address,Gender,Salary,PhoneNumber) values(@Name,@Address,@Gender,@Salary,@PhoneNumber);

	