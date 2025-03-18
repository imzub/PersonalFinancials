CREATE TABLE tbl_AdvanceZakat (
    advZakatId BIGINT IDENTITY(1,1) NOT NULL,
    advZakatIn DECIMAL(18,4) NOT NULL,
    advZakatOut DECIMAL(18,4) NOT NULL,
    advZakatBalance DECIMAL(18,4) NOT NULL,
    assetId BIGINT NULL,
    advZakatPaidTo VARCHAR(MAX) NULL,
    advZakatPaidDate DATETIME NOT NULL,
    isAdvZakatPaid BIT NOT NULL,
    isActive BIT NOT NULL,
    comments VARCHAR(MAX) NULL,
    timestamp DATETIME NULL DEFAULT GETDATE(),
    CONSTRAINT pk_tbl_AdvanceZakat PRIMARY KEY (advZakatId)    
);
