create procedure Usp_InsertEmployee
(
	@EmployeeId int,
	@Name varchar(50),
	@DOB varchar(50),
	@Gender varchar(50),
	@Salary varchar(50)
)

as begin
insert into Employee (EmployeeId,Name,DOB,Gender,Salary) values(@EmployeeId,@Name,@DOB,@Gender,@Salary)
end


