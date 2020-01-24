/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


declare @addressId int
declare @classId int

insert into [Address] values ('Street1', 'City1', 'QC', 'A1B2C3')
set @addressId = @@IDENTITY

insert into [Class] values ('200', 'Computers')
set @classId = @@IDENTITY

insert into [Student] values ('Carlos', 'Bilbao', '111-222-333', @addressId, @classId)