
CREATE DATABASE schedule;
GO



CREATE TABLE Remin ( 
	Id int NOT NULL,    --  ����ID 
	Note varchar(max),    --  �������� 
	mon int,    --  �����·� 
	day int    --  �������� 
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









--Ϊ����Ӹ��ӵ�������Ϣ

EXEC sp_addextendedproperty 'MS_Description', '��Ҫ���ѱ�', 'Schema', dbo, 'table', Remin
;
EXEC sp_addextendedproperty 'MS_Description', '����ID', 'Schema', dbo, 'table', Remin, 'column', Id
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Remin, 'column', Note
;

EXEC sp_addextendedproperty 'MS_Description', '�����·�', 'Schema', dbo, 'table', Remin, 'column', mon
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'Schema', dbo, 'table', Remin, 'column', day
;
