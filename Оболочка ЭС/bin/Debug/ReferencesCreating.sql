
alter table [Variables] add constraint FK_Variables_Domains foreign key ([DomainID]) references [Domains] ([ID]);
alter table [DomainValues] add constraint FK_DomainValues_Domains foreign key ([DomainID]) references [Domains] ([ID])
	on delete cascade on update cascade;
alter table [DomainValues] add constraint FK_DomainValues_Values foreign key ([DomainID]) references [Values] ([ID])
	on delete cascade on update cascade;
alter table [Facts] add constraint FK_Facts_Variables foreign key ([VariableID]) references 
	[Variables] ([ID]) on delete cascade on update cascade;
alter table [Facts] add constraint FK_Facts_Values foreign key ([ValueID]) references 
	[Values] ([ID]) on delete cascade on update cascade;
alter table [IfThen] add constraint FK_IfThen_Facts foreign key ([FactID]) references 
	[Facts] ([ID]) on delete cascade on update cascade;
alter table [IfThen] add constraint FK_IfThen_Rules foreign key ([RuleID]) references 
	[Rules] ([ID]) on delete cascade on update cascade;
