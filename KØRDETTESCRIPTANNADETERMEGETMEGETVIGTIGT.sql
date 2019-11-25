USE [buzzerbase]
GO

/****** Object:  StoredProcedure [dbo].[getmatches]    Script Date: 25/11/2019 14.58.17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter procedure [dbo].[getmatches] @userid int
as
select hivemember.id, firstname, lastname, nick, bio from hivemember
join match on match.firstbuzzerid = hivemember.id
where lastbuzzerid = @userid
union
select hivemember.id, firstname, lastname, nick, bio from hivemember
join match on match.lastbuzzerid= hivemember.id
where firstbuzzerid = @userid

GO


