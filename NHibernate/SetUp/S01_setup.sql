USE GrumpiesHandsOnLabs
GO


PRINT N'Creating schema'+char(13)+char(10)

CREATE TABLE dbo.Customer
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	SurName nvarchar(50) NOT NULL,
	EMail nvarchar(100) NULL,
	BirthDate date NOT NULL
	)  ON [PRIMARY]
GO

PRINT N'Schema Created'+char(13)+char(10)