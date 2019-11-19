create view randommemberstory
as
select top 1 * from memberstory
ORDER BY CHECKSUM(NEWID())