create procedure Usp_GetEmployeeDetails 
(
 @EmployeeId int
)
as begin
select * from Employee where EmployeeId = @EmployeeId
end

