USE family;

insert into familyTree(Person_Id ,Relativ​e_Id ,Co‌nnection‌_Type)
select Person_Id ,Father_Id ,'אב'
from Person 
where Father_Id is not null
union all
select Person_Id ,Mother_Id ,'אם'
from Person
where Mother_Id is not null
union all
select p.Person_Id ,p.Spouse_Id,
case
	when p.Gender = 'male' then 'בת זוג'
    when p.Gender = 'female' then 'בן זוג'
end as Connection_Type
from Person p
where Spouse_Id is not null
union all
select p1.Person_Id ,p2.Person_Id,
case
	when p1.gender = 'male' then 'אח'
	when p1.gender = 'female' then 'אחות'
end as Connection_Type
from Person p1
join Person p2
	on (
        p1.Father_Id is not null and p1.Father_Id = p2.Father_Id
		or p1.Mother_Id is not null and p1.Mother_Id = p2.Mother_Id
        )
where p1.Person_Id <> p2.Person_Id;


 TRUNCATE TABLE FamilyTree;
 



