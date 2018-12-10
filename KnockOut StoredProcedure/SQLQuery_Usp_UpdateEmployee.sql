
create procedure Usp_UpdateEmployee

(@EmployeeId int,@Name varchar(50),@DOB varchar(50),@Gender varchar(50),@Salary varchar(50))
as
begin 
update Employee 
set Name=@Name, DOB=@DOB,  Gender=@Gender, Salary=@Salary
where EmployeeId=@EmployeeId;
end