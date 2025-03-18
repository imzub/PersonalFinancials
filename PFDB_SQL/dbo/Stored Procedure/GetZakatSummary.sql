CREATE PROCEDURE GetZakatSummary
AS
BEGIN
    -- Declare output variables
    DECLARE @TotalActiveDueZakat DECIMAL(18,2);
    DECLARE @BalanceZakat DECIMAL(18,2);

    -- Calculate total due zakat (active)
    SELECT @TotalActiveDueZakat = ISNULL(SUM(DueZakat), 0) 
    FROM tbl_ZakatDue 
    WHERE isZakatDueActive = 1;

    -- Calculate total balance zakat (active)
    SELECT @BalanceZakat = ISNULL(SUM(advZakatBalance), 0) 
    FROM tbl_AdvanceZakat 
    WHERE isActive = 1;

    -- Return both values
    SELECT 
        @TotalActiveDueZakat AS TotalActiveDueZakat, 
        @BalanceZakat AS BalanceZakat;
END;
