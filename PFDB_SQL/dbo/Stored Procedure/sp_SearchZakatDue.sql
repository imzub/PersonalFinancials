CREATE PROCEDURE sp_SearchZakatDue
    @AssetId BIGINT = NULL,
    @AssetName VARCHAR(255) = NULL,
    @UserName VARCHAR(255) = NULL,
    @IsZakatDueActive BIT = NULL -- 🔹 Updated parameter
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        zd.zakatDueId,
        zd.assetId,
        a.assetName,
        u.userName,
        zd.dueZakat,
        zd.isZakatDueActive -- 🔹 Now correctly selecting zakat due status
    FROM tbl_ZakatDue zd
    INNER JOIN tbl_Assets a ON zd.assetId = a.assetId
    INNER JOIN tbl_Users u ON a.userId = u.userId
    WHERE 
        (@AssetId IS NULL OR zd.assetId = @AssetId)
        AND (@AssetName IS NULL OR a.assetName LIKE '%' + @AssetName + '%')
        AND (@UserName IS NULL OR u.userName LIKE '%' + @UserName + '%')
        AND (@IsZakatDueActive IS NULL OR zd.isZakatDueActive = @IsZakatDueActive) -- 🔹 Fixed filtering
END;
