

	

	alter procedure spAddEmployee
	@Name varchar(200),
	@Address nvarchar(200),
	@Gender char(1),
	@Salary float,
	@PhoneNumber bigint
	As
	insert into employee_payroll2(Name,Address,Gender,Salary,PhoneNumber) values(@Name,@Address,@Gender,@Salary,@PhoneNumber);

	alter procedure spUpdateEmployee
		@Name varchar(200),
		@Id int,
		@Salary float
		As
		update employee_payroll2 set Salary=@Salary where Id=@Id and Name=@Name;



		create procedure spDeleteEmployee
			@Name varchar(200),
			@Id int
			As
			delete from employee_payroll2 where Id=@Id and Name=@Name;



	create procedure [dbo].[spInsertIntoTwoTable](
			@Name varchar(200),
			@Address varchar(200),
			@Gender char(1),
			@id INT OUTPUT
			)
			As
			insert into employee_payroll2(Name,Address,Gender)values(@Name,@Address,@Gender);
			SET @id=SCOPE_IDENTITY()
			RETURN @id;


			create table Salary(
			SalaryId int identity(1,1) PRIMARY KEY,
			Salary float,
			EmpId int FOREIGN KEY REFERENCES employee_payroll2(Id)
			);