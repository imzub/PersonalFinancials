CREATE TABLE tbl_AssetZakatFinYear (
    assetZakatFinYearId BIGINT IDENTITY(1,1) NOT NULL,
    assetId BIGINT NOT NULL,
    assetZakatFinYearStartDate DATE NOT NULL,
    assetZakatFinYearEndDate DATE NOT NULL,
    isAssetZakatFinYearActive BIT NOT NULL,
    CONSTRAINT pk_tbl_AssetZakatFinYear PRIMARY KEY (assetZakatFinYearId),
    CONSTRAINT fk_tbl_AssetZakatFinYear_asset FOREIGN KEY (assetId) REFERENCES tbl_Assets (assetId)
);