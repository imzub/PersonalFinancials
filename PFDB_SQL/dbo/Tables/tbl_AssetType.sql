CREATE TABLE tbl_AssetType (
    assetTypeId BIGINT IDENTITY(1,1) NOT NULL,
    assetTypeName VARCHAR(255) NOT NULL,
    assetTypeDesc VARCHAR(MAX) NULL,
    assetTypeCurrentValuePerUnit DECIMAL(18,2) NOT NULL,
    CONSTRAINT pk_tbl_AssetType PRIMARY KEY (assetTypeId)
);