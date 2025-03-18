CREATE TABLE [dbo].[tbl_ApplicationConfiguration]
(
	[appConfigId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [appKey] VARCHAR(MAX) NULL, 
    [appKeyValue] VARCHAR(MAX) NULL, 
    [appConfigTimeStamp] DATETIME NULL
)
