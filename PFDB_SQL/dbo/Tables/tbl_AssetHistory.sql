CREATE TABLE dbo.tbl_AssetHistory (
    assetHistoryId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    assetId BIGINT NULL,
    assetOldValue VARCHAR(MAX) NULL,
    assetNewValue VARCHAR(MAX) NULL,
    assetHistoryTimeStamp DATETIME NOT NULL DEFAULT GETDATE(),
);
