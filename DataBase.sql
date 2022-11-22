create database WebSiteTuyenDung
go

use WebSiteTuyenDung
go

create table Contact
(
	ContactId int primary key identity(1,1) not null,
	Name nvarchar(50),
	Email varchar(50),
	Subject nvarchar(100),
	Message nvarchar(Max),
)
go


drop table Account
create table Account
(
	AccountId int primary key identity(1,1) not null,
	UserName char(100),
	PassWord nvarchar(100)
)
go
Alter table Account add unique(Username)

Alter table Account add unique(UserName)


create table Country
(
	CountryId int primary key identity(1,1) not null,
	Name nvarchar(50)
)
go

create table JobType
(
	JobTypes int primary key identity(1,1) not null,
	Name nvarchar(50)
)
go

drop table [User]

create table [User]
(
	UserId int primary key identity(1,1) not null,
	Name nvarchar(100),
	Email varchar(50),
	Mobile varchar(20),
	Favourite nvarchar(max),
	WorksOn nvarchar(50),
	Experience nvarchar(50),
	Resume nvarchar(200),
	Address nvarchar(max),
	Country nvarchar(50),
	UserImage nvarchar(200),
	Status bit default 0,
	AccountId int, 
	foreign key  (AccountId) references Account(AccountId)
)
go


drop table Company
create table Company 
( 
	CompanyId int primary key identity(1,1) not null,
	CompanyName nvarchar(50),
	CompanyImage nvarchar(500),
	Website varchar(100),
	Email varchar(100),
	Mobile varchar(20),
	Address nvarchar(Max),
	City nvarchar(50),
	Country nvarchar(50),
	Satus bit default 0,
	AccountId int, 
	foreign key  (AccountId) references Account(AccountId)
)
go


drop table Jobs
create table Jobs
(
	JobId int primary key identity(1,1) not null,
	Title nvarchar(50),
	NoNumberPost int,
	Description nvarchar(Max),
	Qualification nvarchar(100),
	Experience nvarchar(50),
	Specialization nvarchar(Max),
	LastDateToApply Date,
	Salary nvarchar(50),
	JobType nvarchar(50),
	CreateDate DateTime,
	Status bit default 0,
	CompanyId int,
	foreign key (CompanyId) references Company(CompanyId)
)
go


drop table AppliedJobs
create table AppliedJobs 
(
	AppliedJobsId int primary key identity(1,1) not null,
	JobId int,
	UserId int,
	Status bit default 0,
	foreign key (JobId) references Jobs(JobId),
	foreign key(UserId) references [User](UserId)
)
go


insert into Country values(N'Việt Nam')
insert into Country values(N'Trung Quốc')
insert into Country values(N'Nhật Bản')
insert into Country values(N'Mỹ')


insert into JobType values(N'Full Time')
insert into JobType values(N'Part Time')
insert into JobType values(N'Remote')
insert into JobType values(N'FreeLance')


select *from Contact

select *from Account
Select * from [User] 

select *from Account 
select *from Jobs
select *from Company


select *from AppliedJobs

Select Row_Number() over(Order by (Select 1)) as [STT], aj.AppliedJobsId, j.CompanyName, aj.JobId,j.Title,
u.Mobile,u.Name, u.Email, u.Resume from AppliedJobs aj
inner join [User] u on aj.UserId = u.UserId
inner join Jobs j on aj.JobId = j.JobId

select *from Jobs order by CreateDate DESC

Select * from Company

select *from Account

select *from [User]
select *from Jobs
select *from AppliedJobs

Select * from AppliedJobs where UserId = 4 and JobId = 23 and Status = 1 and AppliedJobs = ?

Select aj.AppliedJobsId, aj.JobId, aj.Status, aj.UserId
from AppliedJobs aj
inner join Jobs j on j.JobId = aj.JobId
inner join [User] u on u.UserId = aj.UserId
where u.UserId = 4 and j.JobId = 29 and aj.Status = 1

update AppliedJobs set Status = 0 where AppliedJobsId = 10

Select Row_Number() over(Order by (Select 1)) as [STT], aj.AppliedJobsId, aj.JobId, c.CompanyName, j.Title,
                      u.Mobile,u.Name, U.Email, u.Resume from AppliedJobs aj
                      inner join [User] u on aj.UserId = u.UserId
                      inner join Jobs j on aj.JobId = j.JobId
					  inner join Company c on c.CompanyId = 1 

Select Row_Number() over(Order by (Select 1)) as [STT], aj.AppliedJobsId, aj.JobId, c.CompanyName, j.Title,
                      u.Mobile,u.Name, U.Email, u.Resume from AppliedJobs aj
                      inner join [User] u on aj.UserId = u.UserId
                      inner join Jobs j on aj.JobId = j.JobId
					  inner join Company c on c.CompanyId = j.CompanyId
                      where c.CompanyId = 1 and aj.Status = 0