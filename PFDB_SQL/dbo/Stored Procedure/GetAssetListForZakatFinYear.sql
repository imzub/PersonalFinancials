CREATE PROCEDURE GetAssetListForZakatFinYear
AS
BEGIN
    SET NOCOUNT ON;

    SELECT assetId, assetName 
    FROM tbl_Assets
    WHERE isAssetActive = 1  -- Fetch only active assets
    ORDER BY assetName;      -- Sort alphabetically for better usability
END;
