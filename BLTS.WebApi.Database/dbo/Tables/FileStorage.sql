CREATE TABLE [dbo].[FileStorage] (
    [FileStorageId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [ContentType]          NVARCHAR (255) NOT NULL,
    [FileName]             NVARCHAR (255) NOT NULL,
    [RootPath]             NVARCHAR (255) NOT NULL,
    [SizeKB]               BIGINT         NOT NULL,
    [SubPath]              NVARCHAR (255) NOT NULL,
    [CreationDate]         DATETIME2 (7)  CONSTRAINT [DF_FileStorage_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate] DATETIME2 (7)  CONSTRAINT [DF_FileStorage_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_FileStorage_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_FileStorage] PRIMARY KEY CLUSTERED ([FileStorageId] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = OFF, PAD_INDEX = ON, DATA_COMPRESSION = ROW)
);


GO
ALTER TABLE [dbo].[FileStorage] SET (LOCK_ESCALATION = AUTO);



