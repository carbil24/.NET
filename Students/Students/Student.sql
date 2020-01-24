CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [PhoneNumebr] NVARCHAR(15) NULL, 
    [AddressId] INT NOT NULL, 
    [ClassId] INT NOT NULL, 
    CONSTRAINT [FK_Student_Address] FOREIGN KEY (AddressId) REFERENCES Address(Id), 
    CONSTRAINT [FK_Student_Class] FOREIGN KEY (ClassId) REFERENCES Class(Id) 
)
