CREATE SCHEMA `family` ;
USE family;

create table Person(
Person_Id int primary key not null ,
Рersona​l_Name varchar(100) not null ,
Family_Name varchar(100) not null ,
Gender varchar(10) ,
Father_Id int ,
Mother_Id int ,
Spouse_Id int
);

create table FamilyTree(
Person_Id int not null ,
Relativ​e_Id int not null,
Co‌nnection‌_Type varchar(10) not null,
foreign key (Person_Id) references Person(Person_Id),
check (Co‌nnection‌_Type in ('בת זוג','בן זוג','בת','בן','אחות','אח','אם','אב')),
PRIMARY KEY (Person_Id, Relativ​e_Id, Co‌nnection‌_Type)
);

SHOW TABLES;
