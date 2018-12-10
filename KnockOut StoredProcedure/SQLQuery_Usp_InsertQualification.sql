
create Procedure Usp_InsertQualification

(@EmployeeId int,@QualId int,@Marks varchar(50))

as 
Begin 
Insert into Qualification(EmployeeId,QualId,Marks) values(@EmployeeId,@QualId,@Marks);
End

