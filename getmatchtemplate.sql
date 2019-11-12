alter procedure GetPotentialMatch @userid int
as
begin
declare @male int
set @male = (select iif((select top 1 genderid from hivemember where id = @userid) = 2, 1, 0))
declare @female int
set @female = (select iif(@male = 1, 0, 1))
declare @prefmale int
set @prefmale = (select top 1 attractionmale from preferences join hivemember on hivemember.preferenceid = preferences.id where hivemember.id = @userid)
declare @prefemale int
set @prefemale = (select top 1 attractionfemale from preferences join hivemember on hivemember.preferenceid = preferences.id where hivemember.id = @userid)

select @male,@female,@prefmale,@prefemale

select top 1 hivemember.id from hivemember
left join preferences on preferences.id = hivemember.preferenceid
WHERE usertypeid != (select top 1 usertypeid from hivemember where id = @userid)
AND
(
preferences.attractionfemale = @female
AND preferences.attractionfemale = 1
or 
preferences.attractionmale = @male
AND preferences.attractionmale = 1
)
AND
(
(select iif(hivemember.genderid = 1, 1, 0)) = @prefemale
AND @prefemale = 1
OR (select iif(hivemember.genderid = 2, 1, 0)) = @prefmale
AND @prefmale = 1
)
AND
hivemember.id != @userid
AND 
(select count(id) from buzz where buzzerid = @userid AND buzzeeid = hivemember.id) = 0

end