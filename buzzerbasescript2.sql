use master;

drop database buzzerbase;
create database buzzerbase;


use buzzerbase;

create table usertype(
	id int identity primary key,
	typename nvarchar (50) not null unique
);

create table haircolor(
	id int identity primary key,
	color varchar(50) not null unique
);

create table eyecolor(
	id int identity primary key,
	color varchar(50) not null unique
);


create table preferences(
	id int identity primary key,
	haircolorid int foreign key references haircolor(id),
	eyecolorid int foreign key references eyecolor(id),
	heightmin int,
	heightmax int,
	weightmin int,
	weightmax int, 
	attractionmale bit not null default (0),
	attractionfemale bit not null default (0),
);

create table hivemember(
	id int identity primary key,
	preferenceid int foreign key references preferences(id),
	usertypeid int foreign key references usertype(id),
	firstname nvarchar (50) not null,
	lastname nvarchar (50) not null,
	nick nvarchar (50),
	email nvarchar (100) not null unique,
	birthdate date not null,
	bio nvarchar (1000),
	jobtitle nvarchar (50)
);

create table userlogin(
	id int identity primary key,
	userid int foreign key references hivemember(id),
	pass nvarchar (30) not null
);

create table gender(
	id int identity primary key,
	gender char not null unique
);

create table beetails(
	id int identity primary key,
	hivememberid int foreign key references hivemember(id),
	haircolorid int foreign key references haircolor(id),
	eyecolorid int foreign key references eyecolor(id),
	height int,
	weight int,
	genderid int foreign key references gender(id)
);



create table buzz(
	id int identity primary key,
	buzzerid int foreign key references hivemember(id),
	buzzeeid int foreign key references hivemember(id),
	timestamp datetime not null default(getdate())
);
	
create table match(
	id int identity primary key,
	firstbuzzerid int foreign key references hivemember(id),
	lastbuzzerid int foreign key references hivemember(id),
	timeofcreation datetime not null default(getdate())
);
	
create table message(
	id int identity primary key,
	senderid int foreign key references hivemember(id),
	recieverid int foreign key references hivemember(id),
	timestamp datetime not null default(getdate()),
	text nvarchar (500) not null,
	isread bit default(0) not null
);

create table image(
	id int identity primary key,
	hivememberid int foreign key references hivemember(id),
	imagename nvarchar(255) not null,
	constraint useridimagenameconst unique(hivememberid, imagename)
);

create table memberstory(
	id int identity primary key,
	story varchar (500) not null,
	imagepath varchar (255) not null
);