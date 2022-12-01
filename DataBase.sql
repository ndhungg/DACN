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
	PassWord nvarchar(100),
	Status int,
)
go

Alter table Account add unique(Username)



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

Alter table [User] add unique(Email)


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

Alter table Company add unique(Email)


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
	foreign key (JobId) references Jobs(JobId),
	foreign key(UserId) references [User](UserId)
)
go

drop table Question
create table Question
(
	QuestionId int primary key identity(1,1) not null,
	question1 nvarchar(Max),
	question2 nvarchar(Max),
	question3 nvarchar(Max),
	Status bit default 0,
	CompanyId int,
	foreign key (CompanyId) references Company(CompanyId),
	
)
go


drop table FeedBack
create table FeedBack 
(
	FeedBackId int primary key identity(1,1) not null,
	feedBack1 nvarchar(Max),
	feedBack2 nvarchar(Max),
	feedBack3 nvarchar(Max),
	AppliedJobsId int,
	foreign key (AppliedJobsId) references AppliedJobs(AppliedJobsId),
)
go

drop table SendQuestions
create table SendQuestions
(
	SendQuestionId int primary key identity(1,1) not null,
	QuestionId int,
	AppliedJobsId int,
	foreign key (QuestionId) references Question(QuestionId),
	foreign key (AppliedJobsId) references AppliedJobs(AppliedJobsId),
)
go

drop table savedata
create table SaveData
(
	SaveDataId int primary key identity(1,1) not null,
	SendQuestionId int,
	FeedBackId int,
	foreign key (SendQuestionId) references SendQuestions(SendQuestionId),
	foreign key (FeedBackId) references FeedBack(FeedBackId),
)
go


insert into Country values(N'Việt Nam')
insert into Country values(N'Trung Quốc')
insert into Country values(N'Nhật Bản')


insert into JobType values(N'Full Time')
insert into JobType values(N'Part Time')
insert into JobType values(N'Remote')
insert into JobType values(N'FreeLance')

