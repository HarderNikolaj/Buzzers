create procedure getmatches @userid int
as
select hivemember.id, firstname, lastname, nick from hivemember
join match on match.firstbuzzerid = hivemember.id
where lastbuzzerid = @userid
union
select hivemember.id, firstname, lastname, nick from hivemember
join match on match.lastbuzzerid= hivemember.id
where firstbuzzerid = @userid

