CREATE TABLE tbl_FinancialYear (
    financialYearId BIGINT IDENTITY(1,1) NOT NULL,
    financialYearName VARCHAR(255) NOT NULL,
    financialYearDesc VARCHAR(500) NULL,
    financialYearStartDate DATE NOT NULL,
    financialYearEndDate DATE NOT NULL,
    CONSTRAINT pk_tbl_FinancialYear PRIMARY KEY (financialYearId)
);
