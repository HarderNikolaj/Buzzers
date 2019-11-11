create procedure GetPotentialMatch @userid int, @usertypeid int, @genderid int, @prefmale int, @preffemale int
as
begin
declare @male int
set @male = (select iif(@genderid = 2, 1, 0))
declare @female int
set @female = (select iif(@genderid = 1, 1, 0))

select top 1 hivemember.id from hivemember
join preferences on hivemember.preferenceid = preferences.id
WHERE usertypeid != @usertypeid 
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
(select iif(hivemember.genderid = 1, 1, 0)) = @preffemale
AND @preffemale = 1
OR (select iif(hivemember.genderid = 2, 1, 0)) = @prefmale
AND @prefmale = 1
)
AND
hivemember.id != @userid
AND 
(select count(id) from buzz where buzzerid = @userid AND buzzeeid = hivemember.id) = 0

end