CREATE TABLE tbl_ZakatDue (
    zakatDueId BIGINT IDENTITY(1,1) NOT NULL,
    assetId BIGINT NOT NULL,
    dueZakat DECIMAL(18,4) NOT NULL,
    isZakatDueActive BIT NOT NULL,
    CONSTRAINT pk_tbl_ZakatDue PRIMARY KEY (zakatDueId),
    CONSTRAINT fk_tbl_ZakatDue_AssetId FOREIGN KEY (assetId) REFERENCES tbl_Assets(assetId) ON DELETE CASCADE
);
