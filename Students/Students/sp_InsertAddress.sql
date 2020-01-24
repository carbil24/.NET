CREATE PROCEDURE [dbo].[sp_InsertAddress]
	@street NVarchar(50),
	@city NVarchar(50),
	@province Char(7),
	@postalCode Char(2)
AS
	Begin Try
        insert into Address values (@street, @city, @province, @postalcode)
		RETURN 1
	End Try
	Begin Catch
		RETURN 0
	End Catch