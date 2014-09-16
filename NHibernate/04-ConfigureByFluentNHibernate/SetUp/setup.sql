USE GrumpiesHandsOnLabs
GO

PRINT N'Cleaning schema'+char(13)+char(10)

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
DROP TABLE [dbo].[Customer]
GO

PRINT N'Schema cleaned'+char(13)+char(10)

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