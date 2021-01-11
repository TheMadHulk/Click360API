DROP TABLE [dbo].[SearchEngineData]
GO

CREATE TABLE [dbo].[SearchEngineData](
	[ObjectType] [tinyint] NOT NULL,
	[FieldName] [nvarchar](32) NOT NULL,
	[PrimaryKey] [int] NOT NULL,
	[FieldData] [nvarchar](1024) NULL,
    [SortData] [nvarchar](32) NOT NULL
) ON [PRIMARY]
GO

CREATE UNIQUE CLUSTERED INDEX [idx_SearchEngineData_ClusteredIndex] ON [dbo].[SearchEngineData] ([ObjectType] ASC, [FieldName] ASC, [PrimaryKey] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



/*********
 ** Import data from jobs into search data
 **/
INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData], [SortData])
SELECT [JobID] as [PrimaryKey], 1 as [ObjectType], 'Title' as  [FieldName], [Title], LEFT([Title], 32) as [SortData]
FROM Job
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData], [SortData])
SELECT [JobID] as [PrimaryKey], 1 as [ObjectType], 'Description' as  [FieldName], LEFT([Description],1024), LEFT([Title], 32) as [SortData]
FROM Job
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [JobID] as [PrimaryKey], 1 as [ObjectType], 'SOCCode' as  [FieldName], [SOCCode], LEFT([Title], 32) as [SortData]
FROM Job
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [JobID] as [PrimaryKey], 1 as [ObjectType], 'JobZone' as  [FieldName], [JobZone], LEFT([Title], 32) as [SortData]
FROM Job
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [JobID] as [PrimaryKey], 1 as [ObjectType], 'RTI' as  [FieldName], [RTI], LEFT([Title], 32) as [SortData]
FROM Job
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData], [SortData])
SELECT [JobID] as [PrimaryKey], 1 as [ObjectType], 'Comments' as  [FieldName], LEFT([Comments],1024), LEFT([Title], 32) as [SortData]
FROM Job
GO



/*********
 ** Import data from programs into search data
 **/
INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [ProgramId] as [PrimaryKey], 2 as [ObjectType], 'Title' as  [FieldName], [Title], LEFT([Title], 32) as [SortData]
FROM Program
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [ProgramId] as [PrimaryKey], 2 as [ObjectType], 'Description' as  [FieldName], LEFT([Description],1024), LEFT([Title], 32) as [SortData]
FROM Program
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [ProgramId] as [PrimaryKey], 2 as [ObjectType], 'ProgramDeveloper' as  [FieldName], ProgramDeveloper, LEFT([Title], 32) as [SortData]
FROM Program
GO



/*********
 ** Import data from provider into search data
 **/
INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [ProviderId] as [PrimaryKey], 3 as [ObjectType], 'Name' as  [FieldName], [Name], LEFT([Name], 32) as [SortData]
FROM [Provider]
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [ProviderId] as [PrimaryKey], 3 as [ObjectType], 'Description' as  [FieldName], LEFT([Description],1024), LEFT([Name], 32) as [SortData]
FROM [Provider]
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT [ProviderId] as [PrimaryKey], 3 as [ObjectType], 'ExternalId' as  [FieldName], ExternalId, LEFT([Name], 32) as [SortData]
FROM [Provider]
GO



/*********
 ** Import data from subject into search data (This now comes from VPT accounts)
 **
INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 4 as [ObjectType], 'FirstName' as  [FieldName], [FirstName], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 1
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 4 as [ObjectType], 'MiddleName' as  [FieldName], [MiddleName], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 1
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 4 as [ObjectType], 'LastName' as  [FieldName], [LastName], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 1
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 4 as [ObjectType], 'Title' as  [FieldName], [Title], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 1
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 4 as [ObjectType], 'Email' as  [FieldName], [Email], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 1
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 4 as [ObjectType], 'ExternalId' as  [FieldName], [ExternalId], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 1
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 4 as [ObjectType], 'Username' as  [FieldName], [Username], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 1
GO
 **/



/*********
 ** Import data from agent into search data (This now comes from VPT accounts)
 **
INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 5 as [ObjectType], 'FirstName' as  [FieldName], [FirstName], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 2
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 5 as [ObjectType], 'MiddleName' as  [FieldName], [MiddleName], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 2
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 5 as [ObjectType], 'LastName' as  [FieldName], [LastName], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 2
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 5 as [ObjectType], 'Title' as  [FieldName], [Title], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 2
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 5 as [ObjectType], 'Email' as  [FieldName], [Email], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 2
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 5 as [ObjectType], 'ExternalId' as  [FieldName], [ExternalId], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 2
GO

INSERT INTO [SearchEngineData]([PrimaryKey], [ObjectType], [FieldName], [FieldData] , [SortData])
SELECT p.[PersonID] as [PrimaryKey], 5 as [ObjectType], 'Username' as  [FieldName], [Username], LEFT([LastName] + ', ' + [FirstName], 32) as [SortData]
FROM [Person] p
INNER JOIN [User] u on u.PersonID = p.PersonID
WHERE u.Type = 2
GO
 **/






