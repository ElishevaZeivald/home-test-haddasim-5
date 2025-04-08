USE family;

create trigger before_update_person
before update on Person
for each row
begin
	insert into Person_History(Person_Id ,Personal_Name ,Family_Name ,Gender ,Father_Id ,Mother_Id ,Spouse_Id ,Update_Time)
	values(old.Person_Id ,old.Personal_Name ,OLD.Family_Name ,old.Gender ,old.Father_Id ,old.Mother_Id ,old.Spouse_Id ,now()),
end
//
DELIMITER ;


UPDATE Person p 
JOIN familytree ft ON p.Person_Id = ft.Relativ​e_Id 
SET p.Spouse_Id = ft.Person_Id 
WHERE ft.Co‌nnection‌_Type IN ('בן זוג', 'בת זוג')  
 AND (p.Spouse_Id IS NULL OR p.Spouse_Id != ft.Person_Id)








