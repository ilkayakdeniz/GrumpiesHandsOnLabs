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


CREATE TABLE dbo.Developer
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	SurName nvarchar(50) NOT NULL,
	DepartmentId int NOT NULL	
	)  ON [PRIMARY]
GO


CREATE TABLE dbo.Department
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO



ALTER TABLE dbo.Department ADD CONSTRAINT
	PK_Department PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Department SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.Developer ADD CONSTRAINT
	FK_Developer_Department FOREIGN KEY
	(
	DepartmentId
	) REFERENCES dbo.Department
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Developer SET (LOCK_ESCALATION = TABLE)
GO



CREATE TABLE dbo.Project
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,	
	StartDate date NOT NULL,
	EndDate date NOT NULL
	)  ON [PRIMARY]
GO

CREATE TABLE dbo.Contributor
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	Commits int NOT NULL,
	ProjectId int NULL
	)  ON [PRIMARY]
GO



ALTER TABLE dbo.Project ADD CONSTRAINT
	PK_Project PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Project SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.Contributor ADD CONSTRAINT
	FK_Contributor_Project FOREIGN KEY
	(
	ProjectId
	) REFERENCES dbo.Project
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contributor SET (LOCK_ESCALATION = TABLE)
GO




CREATE TABLE [dbo].[Author](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
	[Price] [numeric](15, 4) NOT NULL,
	[AuthorId] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO

ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]

PRINT N'Schema Created'+char(13)+char(10)