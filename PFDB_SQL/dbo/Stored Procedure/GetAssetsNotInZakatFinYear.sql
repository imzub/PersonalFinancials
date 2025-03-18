CREATE PROCEDURE GetAssetsNotInZakatFinYear
AS
BEGIN
    SET NOCOUNT ON;

    SELECT a.assetId, a.assetName
    FROM tbl_Assets a
    WHERE 
        a.isAssetZakatApplicable = 1  -- Asset should be applicable for Zakat
        AND a.isAssetActive = 1       -- Asset should be active
        AND NOT EXISTS (
            SELECT 1 
            FROM tbl_AssetZakatFinYear az
            WHERE az.assetId = a.assetId
        );
END;
