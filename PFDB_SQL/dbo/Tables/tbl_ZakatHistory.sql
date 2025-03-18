-- 10. Create Zakat History Table (Depends on Assets)
CREATE TABLE dbo.tbl_ZakatHistory (
    zakatHistoryId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    assetId BIGINT NOT NULL,
    assetOldValue DECIMAL(18,4) NOT NULL,
    assetNewValue DECIMAL(18,4) NOT NULL,
    assetHistoryTimeStamp DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_tbl_ZakatHistory_tbl_Assets FOREIGN KEY (assetId) REFERENCES dbo.tbl_Assets (assetId)
);