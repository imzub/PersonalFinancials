CREATE TABLE tbl_YearType (
    yearTypeId BIGINT NOT NULL,
    yearTypeName VARCHAR(255) NOT NULL,
    yearTypeDesc VARCHAR(255) NOT NULL,
    yearTypeDays INT NOT NULL,
    CONSTRAINT pk_tbl_YearType PRIMARY KEY (yearTypeId)
);
