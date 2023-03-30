use demo;


create table software (
	 Software_ID int ,
     Software_Name nvarchar(20),
     Company_Name nvarchar(60),
     Software_Version nvarchar(20),
     Software_Trace nvarchar(40),
     Primary key(Software_ID)
     );
     
-- 0:没有内容的节点 1:有内容的叶节点  
 create table PersonalList (
	PLNode_ID int,
    Software_ID int,
    PLNode_Name nvarchar(20),
    PLNode_Type tinyint,
    Primary key(PLNode_ID),
    foreign key(Software_ID) references software(Software_ID),
    Check ( PLNode_Type in (0, 1) )
 );

 

create table PLNode_Relation (
	Parent_ID int,
    Child_ID int,
    Primary key(Parent_ID, Child_ID),
    foreign key(Parent_ID) references personallist(PLNode_ID),
    foreign key(Child_ID) references personallist(PLNode_ID)
 );

-- 0：无 1：有
create table PLNode_Attributions (
	PLNode_ID int,
    PLNode_Purpose nvarchar(100),
    PlNode_UseCase nvarchar(100),
    PLNode_Collect_Situation tinyint,
    PLNode_Content tinyint,
    Primary key(PLNode_ID),
    foreign key(PLNode_ID) references personallist(PLNode_ID),
    check ( PLNode_Collect_Situation in (0, 1)),
    check ( PLNode_Content in (0, 1) )
 );
 

-- 没定好
create table ThirdList (
	TLNode_ID int,
    Software_ID int,
    TLNode_Type nvarchar(20),
    TLNode_OS nvarchar(20),
    TLNode_Name nvarchar(100),
    TLNode_Company nvarchar(100),
    TLNode_InformationContent nvarchar(300),
    TLNode_Purpose nvarchar(100),
    TLNode_UseCase nvarchar(100),
    TLNode_Way nvarchar(100),
    TLNode_Detailed nvarchar(300),
    primary key(TLNode_ID),
	foreign key(Software_ID) references software(Software_ID)
 );
 

 
 
 