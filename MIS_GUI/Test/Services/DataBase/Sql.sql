CREATE TABLE [USER](
   Uid INT IDENTITY (1,1) PRIMARY KEY ,
   LoginName NVARCHAR(20) UNIQUE ,
   Password NVARCHAR(20),
   Name NVARCHAR(20),
);

CREATE TABLE Team(
    Tid INT IDENTITY (1,1) PRIMARY KEY ,
    Name NVARCHAR(20),
    JoinCode NVARCHAR(9) UNIQUE , -- 加入码
    PeopleNumber INT,
    Description NVARCHAR(120), -- 团队介绍
    [Join] INT DEFAULT 0 -- 加入的设置，0为全部允许，1为允许加入码，2为只允许管理员邀请
);

CREATE TABLE TeamMember(
    Tid INT,
    Uid INT,
    Role NVARCHAR(10),
    FOREIGN KEY (Tid) REFERENCES Team(Tid),
    FOREIGN KEY (Uid) REFERENCES [USER](Uid),
    PRIMARY KEY (Tid,Uid)
);

-- 用户的团队视图
CREATE VIEW UserTeamsView AS 
    SELECT TM.Uid , TM.Tid , T.Name , T.Description , T.PeopleNumber
    FROM TeamMember TM LEFT JOIN Team T on T.Tid = TM.Tid;
GO;

-- 团队成员视图
CREATE VIEW TeamMemberView AS
    SELECT TM.Tid,U.Uid,u.Name,TM.Role
    FROM TeamMember TM LEFT JOIN [USER] U on U.Uid = TM.Tid;
GO;

-- 获取团队信息
CREATE PROCEDURE GetTeamInfo(@tid INT) AS 
    DECLARE @OwnerUid INT;
    DECLARE @OwnerName NVARCHAR(20);
    SELECT @OwnerUid = Uid FROM TeamMember WHERE Role = 'Owner' AND Tid = @tid;
    SELECT @OwnerName = Name FROM [USER] WHERE Uid = @OwnerUid;
    SELECT Name,Description,PeopleNumber,JoinCode,@OwnerUid Uid,@OwnerName UName FROM Team WHERE Tid = @Tid;
GO;

-- 插入团队成员的时候将人数+1
CREATE TRIGGER UpdatePeopleNumber ON TeamMember AFTER INSERT 
    AS 
    DECLARE @tid INT;
    SELECT @tid = Tid FROM inserted;
    UPDATE Team SET PeopleNumber = PeopleNumber + 1 WHERE Tid = @tid;
GO;
    
-- 项目表
CREATE TABLE Task(
    Tid INT IDENTITY (1,1) PRIMARY KEY ,
    Name NVARCHAR(20),
    Description NVARCHAR(max),
    PeopleNumber INT DEFAULT 0,
);

-- 团队项目表
CREATE TABLE TeamTasks(
    TeamId INT REFERENCES Team(Tid),
    TaskId INT REFERENCES Task(Tid),
    PRIMARY KEY (TeamId,TaskId)
);

-- 项目成员表
CREATE TABLE TaskMember(
    Tid INT,
    Uid INT,
    Role NVARCHAR(6),
    FOREIGN KEY (Tid) REFERENCES Task(Tid),
    FOREIGN KEY (Uid) REFERENCES [USER](Uid),
    PRIMARY KEY (Tid,Uid)
);

-- 插入项目成员的时候将人数+1
CREATE TRIGGER UpdatePeopleNumber ON TaskMember AFTER INSERT
    AS
    DECLARE @tid INT;
    SELECT @tid = Tid FROM inserted;
    UPDATE Task SET PeopleNumber = PeopleNumber + 1 WHERE Tid = @tid;
GO;

-- 创建项目
CREATE PROCEDURE CreateTask (@tid INT,@uid INT,@name NVARCHAR(20),@description NVARCHAR(MAX))
AS 
    DECLARE @TaskId INT;
    INSERT INTO Task(name,description) VALUES (@name,@description);
    SET @TaskId = @@IDENTITY;
    INSERT INTO TaskMember(Tid, Uid, Role) VALUES (@TaskId,@tid,'Admin');
    INSERT INTO TeamTasks(TeamId, TaskId) VALUES (@tid,@TaskId);
GO;
    