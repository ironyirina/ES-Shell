create table [Variables] ([ID] int
					constraint PK_Variables primary key ([ID]),
					[Name] nvarchar(50),
					[Type] nvarchar(30),
					[DomainID] int);
					
create table [Domains] ([ID] int
					constraint PK_Domains primary key ([ID]),
					[Name] nvarchar(50));
					
create table [Values] ([ID] int
					constraint PK_Values primary key ([ID]),
					[Value] nvarchar);
					
create table [DomainValues] ([DomainID] int,
					[ValueID] int
					constraint PK_DomainValues primary key ([DomainID], [ValueID]));
	
create table [Rules] ([ID] int
					constraint PK_Rules primary key ([ID]),
					[Name] nvarchar,
					[ConclusionID] int);
					
create table [Facts] ([ID] int
					constraint PK_Facts primary key ([ID]),
					[VariableID] int,
					[ValueID] int,
					[Type] bit);
					
create table [IfThen] ([RuleID] int,
					[FactID] int
					constraint PK_IfThen primary key ([RuleID], [FactID]));