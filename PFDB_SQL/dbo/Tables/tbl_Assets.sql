CREATE TABLE tbl_Assets (
    assetId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    assetTypeId BIGINT NOT NULL,
    userId BIGINT NOT NULL,
    assetName VARCHAR(255) NOT NULL,
    assetDesc VARCHAR(MAX) NULL,
    assetUnits DECIMAL(18,4) NOT NULL, -- Changed to DECIMAL for fractional values
    isAssetZakatApplicable BIT NOT NULL,
    assetBoughtDate DATETIME NULL,
    assetZakatApplicableFromDate DATETIME NULL,
    assetBoughtPrice DECIMAL(18,4) NOT NULL, -- Changed to DECIMAL for precision
    assetTimeStamp DATETIME NOT NULL DEFAULT GETDATE(), -- Default timestamp
    isAssetActive BIT NOT NULL DEFAULT 1, -- Default active status

    -- Foreign Key Constraints
    CONSTRAINT FK_tbl_Assets_AssetType FOREIGN KEY (assetTypeId) REFERENCES tbl_AssetType (assetTypeId),
    CONSTRAINT FK_tbl_Assets_User FOREIGN KEY (userId) REFERENCES tbl_Users (userId)
);
