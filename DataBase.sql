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
select *from Contact


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
	Username varchar(50),
	Password varchar(50),
	Name nvarchar(50),
	Email varchar(50),
	Mobile varchar(20),
	TenthGrade nvarchar(50),
	TwelfthGrade nvarchar(50),
	GraduationGrade nvarchar(30),
	PostGraduationGrade nvarchar(50),
	Phd nvarchar(50),
	WorksOn nvarchar(50),
	Experience nvarchar(50),
	Resume nvarchar(200),
	Address nvarchar(max),
	Country nvarchar(50)
)
go

select *from [User]

-- add condion Username unique
Alter table [User] add unique(Username)

create table Jobs
(
	JobId int primary key identity(1,1) not null,
	Title nvarchar(50),
	NoPost int,
	Description nvarchar(Max),
	Qualification nvarchar(100),
	Experience nvarchar(50),
	Specialization nvarchar(Max),
	LastDateToApply Date,
	Salary nvarchar(50),
	JobType nvarchar(50),
	CompanyName nvarchar(50),
	CompanyImage nvarchar(500),
	Website varchar(100),
	Email varchar(100),
	Address nvarchar(Max),
	City nvarchar(50),
	Country nvarchar(50),
	CreateDate DateTime
)
go

create table AppliedJobs 
(
	AppliedJobsId int primary key identity(1,1) not null,
	JobId int,
	UserId int,
)
go

insert into Country values(N'Việt Nam')
insert into Country values(N'Trung Quốc')
insert into Country values(N'Nhật Bản')
insert into Country values(N'Mỹ')
insert into Country values(N'Ấn Độ')
insert into Country values(N'Nga')


insert into JobType values(N'Full Time')
insert into JobType values(N'Part Time')
insert into JobType values(N'Remote')
insert into JobType values(N'FreeLance')


select *from Contact

Select * from [User] 

select *from Jobs  where Convert(DATE, CreateDate) = ''

select *from AppliedJobs

Select Row_Number() over(Order by (Select 1)) as [STT], aj.AppliedJobsId, j.CompanyName, aj.JobId,j.Title,
u.Mobile,u.Name, u.Email, u.Resume from AppliedJobs aj
inner join [User] u on aj.UserId = u.UserId
inner join Jobs j on aj.JobId = j.JobId

select *from Jobs order by CreateDate DESC