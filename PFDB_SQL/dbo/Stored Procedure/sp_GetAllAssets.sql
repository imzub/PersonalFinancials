CREATE PROCEDURE sp_GetAllAssets
AS
BEGIN
    SELECT a.assetId AS [ID], at.assetTypeName AS [Type], u.userName AS [Owner], 
           a.assetName AS [Name], a.assetUnits AS [Units], a.isAssetZakatApplicable AS [Zakat Applicable], 
           a.assetBoughtDate AS [Bought On], a.assetZakatApplicableFromDate AS [ZakatApplicableDate], a.assetBoughtPrice AS [At Price], a.isAssetActive AS [Active]
    FROM tbl_Assets a
    INNER JOIN tbl_AssetType at ON a.assetTypeId = at.assetTypeId
    INNER JOIN tbl_Users u ON a.userId = u.userId;
END;