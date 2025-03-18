CREATE PROCEDURE GetAssetsNotInZakatFinYearWithDetails
AS
BEGIN
    SET NOCOUNT ON;

    SELECT a.*
    FROM tbl_assets a
    WHERE a.assetId NOT IN (SELECT DISTINCT assetId FROM tbl_AssetZakatFinYear)
          AND a.isAssetZakatApplicable = 1
          AND a.isAssetActive = 1;
END;
