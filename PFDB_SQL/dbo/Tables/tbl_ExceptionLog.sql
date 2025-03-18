CREATE TABLE tbl_ExceptionLog (
    exceptionId BIGINT IDENTITY(1,1) PRIMARY KEY,
    exceptionMessage NVARCHAR(MAX) NOT NULL,
    exceptionStackTrace NVARCHAR(MAX) NOT NULL,
    exceptionSource NVARCHAR(255) NULL,
    exceptionDateTime DATETIME NOT NULL DEFAULT GETDATE()
)
