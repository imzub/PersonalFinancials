CREATE PROCEDURE sp_GetAssetCategorySum
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        at.assetTypeName AS AssetCategory,  -- Get asset category name
        SUM(a.assetUnits * at.assetTypeCurrentValuePerUnit) AS TotalValue -- Calculate total value
    FROM tbl_Assets a
    INNER JOIN tbl_AssetType at ON a.assetTypeId = at.assetTypeId
    WHERE a.isAssetActive = 1  -- Consider only active assets
    GROUP BY at.assetTypeName
    ORDER BY TotalValue DESC;  -- Sort by highest value first
END;
