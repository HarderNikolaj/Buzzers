create trigger [dbo].[OnMutualBuzzCreateMatch]
	on [dbo].[buzz]
	after insert
	as
	begin
	declare @firstbuzzer int
	select @firstbuzzer =  buzzeeid from inserted
	declare @lastbuzzer int
	select @lastbuzzer = buzzerid from inserted
	if (select count(id) from buzz where buzzerid = @firstbuzzer AND isbuzzon = 1) = 1
	begin
	insert into [match] (firstbuzzerid, lastbuzzerid) values (@firstbuzzer, @lastbuzzer)
	end
	end