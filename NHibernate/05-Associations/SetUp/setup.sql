USE GrumpiesHandsOnLabs
GO

PRINT N'Cleaning schema'+char(13)+char(10)

DECLARE @name VARCHAR(128)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP TABLE [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped Table: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 AND [name] > @name ORDER BY [name])
END
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


CREATE TABLE dbo.Adress
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	Street nvarchar(50) NOT NULL,
	PostCode nvarchar(50) NOT NULL
	
	)  ON [PRIMARY]
GO


CREATE TABLE dbo.SalesTrnx
	(
	Id int NOT NULL IDENTITY (1, 1),
	TrnxTime DATETIME NOT NULL,
	TrnxStatus int NOT NULL,
	Volume decimal(6,2) NOT NULL,
	CurrencyCode int NOT NULL
	
	)  ON [PRIMARY]
GO

PRINT N'Schema Created'+char(13)+char(10)