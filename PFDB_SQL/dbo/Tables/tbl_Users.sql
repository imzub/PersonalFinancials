CREATE TABLE tbl_Users (
    userId BIGINT IDENTITY(1,1) NOT NULL,
    userName VARCHAR(255) NOT NULL,
    userDOB DATE NULL,
    CONSTRAINT pk_tbl_Users PRIMARY KEY (userId)
);