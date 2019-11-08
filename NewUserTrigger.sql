create trigger NewUserTrigger
on hivemember
after insert
as
BEGIN
insert into beetails default values
insert into preferences default values
update hivemember set preferenceid = SCOPE_IDENTITY() where id = (select id from inserted)
END
