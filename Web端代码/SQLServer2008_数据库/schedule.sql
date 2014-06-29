
CREATE DATABASE schedule;
GO



CREATE TABLE Remin ( 
	Id int NOT NULL,    --  提醒ID 
	Note varchar(max),    --  提醒内容 
	mon int,    --  提醒月份 
	day int    --  提醒日期 
)
;

CREATE TABLE schedule
(
	Id INTEGER,
	week INTEGER,
	section INTEGER,
	course TEXT,
	addr TEXT,
	course_code TEXT,
	teacher TEXT,
	ClassNo TEXT,
	TeachingWeek TEXT,
	CONSTRAINT PK_schedule PRIMARY KEY (Id)
)
;

CREATE TABLE Student
(
	StudentNo TEXT,
	Name TEXT,
	ClassNO TEXT,
	pwd TEXT,
	phone TEXT,
	email TEXT,
	CONSTRAINT PK_Student PRIMARY KEY (StudentNo)
)
;

CREATE TABLE TClass
(
	ClassNO TEXT,
	ClassName TEXT,
	CONSTRAINT PK_TClass PRIMARY KEY (ClassNO)
)
;

CREATE TABLE Teacher
(
	TeacherNo TEXT,
	Name TEXT,
	pwd TEXT,
	phone TEXT,
	email TEXT,
	address TEXT,
	CONSTRAINT PK_Teacher PRIMARY KEY (TeacherNo)
)
;


ALTER TABLE Remin ADD CONSTRAINT PK_Remin 
	PRIMARY KEY CLUSTERED (Id)
;









--为表添加附加的描述信息

EXEC sp_addextendedproperty 'MS_Description', '重要提醒表', 'Schema', dbo, 'table', Remin
;
EXEC sp_addextendedproperty 'MS_Description', '提醒ID', 'Schema', dbo, 'table', Remin, 'column', Id
;

EXEC sp_addextendedproperty 'MS_Description', '提醒内容', 'Schema', dbo, 'table', Remin, 'column', Note
;

EXEC sp_addextendedproperty 'MS_Description', '提醒月份', 'Schema', dbo, 'table', Remin, 'column', mon
;

EXEC sp_addextendedproperty 'MS_Description', '提醒日期', 'Schema', dbo, 'table', Remin, 'column', day
;
