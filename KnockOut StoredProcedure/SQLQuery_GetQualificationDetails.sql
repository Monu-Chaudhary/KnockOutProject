
create procedure Usp_GetQualificationDetails

(@EmployeeId int)
as begin


select * from Qualification where EmployeeId=@EmployeeId
end
