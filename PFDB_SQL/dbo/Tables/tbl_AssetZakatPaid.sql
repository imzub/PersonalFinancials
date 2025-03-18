CREATE TABLE tbl_AssetZakatPaid (
    assetZakatPaidId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    assetId BIGINT NOT NULL,
    periodFrom DATETIME NOT NULL,
    periodTo DATETIME NOT NULL,
    amountPaid DECIMAL(18,4) NOT NULL,
    timeStamp DATETIME NOT NULL,
    isActive BIT NOT NULL
);