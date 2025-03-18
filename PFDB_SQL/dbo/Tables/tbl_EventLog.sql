CREATE TABLE tbl_EventLog (
    EventID INT IDENTITY(1,1) PRIMARY KEY, -- Unique Event ID
    EventType NVARCHAR(50) NOT NULL,       -- Type of event (Error, Info, Warning, etc.)
    EventMessage NVARCHAR(MAX) NOT NULL,   -- Detailed event description
    EventSource NVARCHAR(100) NOT NULL,    -- Source of event (e.g., Form Name, Module Name)
    UserName NVARCHAR(100) NULL,           -- User who triggered the event
    CreatedAt DATETIME DEFAULT GETDATE(),  -- Timestamp of event
    AdditionalData NVARCHAR(MAX) NULL      -- Any extra data (JSON/XML)
);
