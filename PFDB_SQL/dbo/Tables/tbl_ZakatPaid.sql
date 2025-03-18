CREATE TABLE tbl_ZakatPaid (
    zakatPaidId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    assetId BIGINT NOT NULL,
    zakatPaidTo VARCHAR(255) NULL,
    zakatPaidAmount DECIMAL(18,4) NOT NULL, -- Changed to DECIMAL for precision
    zakatPaidDate DATETIME NOT NULL DEFAULT GETDATE(), -- Default to current date
    isZakatDueUpdated BIT NOT NULL DEFAULT 0, -- Default to false

    -- Foreign Key Constraint
    CONSTRAINT FK_tbl_ZakatPaid_Asset FOREIGN KEY (assetId) REFERENCES tbl_Assets (assetId)
);
