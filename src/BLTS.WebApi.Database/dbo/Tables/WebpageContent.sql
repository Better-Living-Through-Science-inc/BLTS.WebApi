CREATE TABLE [dbo].[WebpageContent] (
    [WebpageContentId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Title]                   NVARCHAR (255) NOT NULL,
    [Metatag]                 NVARCHAR (255) NULL,
    [Description]             NVARCHAR (255) NULL,
    [Body]                    NVARCHAR (MAX) NOT NULL,
    [Footer]                  NVARCHAR (MAX) NULL,
    [IsAuthorizationRequired] BIT            CONSTRAINT [DF_WebpageContent_IsAuthorizationRequired] DEFAULT ((0)) NOT NULL,
    [CreationDate]            DATETIME2 (7)  CONSTRAINT [DF_WebpageContent_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]    DATETIME2 (7)  CONSTRAINT [DF_WebpageContent_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF_WebpageContent_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_WebpageContent] PRIMARY KEY CLUSTERED ([WebpageContentId] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = OFF, PAD_INDEX = ON)
);


GO
ALTER TABLE [dbo].[WebpageContent] SET (LOCK_ESCALATION = AUTO);







GO




