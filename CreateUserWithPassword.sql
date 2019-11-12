CREATE PROCEDURE CreateUserWithLogin @usertypeid int, @genderid int, @firstname nvarchar(50), @lastname nvarchar(50),@email nvarchar(100), @birthdate date, @jobtitle string, @pass nvarchar(30)
AS
declare @success bit
BEGIN TRY
INSERT INTO hivemember (usertypeid, genderid, firstname, lastname, email, birthdate, jobtitle) values (@usertypeid, @genderid,@firstname,@lastname,@email,@birthdate,@jobtitle)
INSERT INTO userlogin (userid, pass) values (SCOPE_IDENTITY(), @pass)
SET @success = 1
END TRY
BEGIN CATCH
SET @success = 0
END CATCH
SELECT @success
