CREATE TABLE [dbo].[WebpageContentPermission] (
    [WebpageContentPermissionId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [WebpageContentId]           BIGINT        NOT NULL,
    [ActiveDirectoryGroupId]     BIGINT        NOT NULL,
    [IsEnabled]                  BIT           CONSTRAINT [DF_WebpageContentPermission_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]               DATETIME2 (7) CONSTRAINT [DF_WebpageContentPermission_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]       DATETIME2 (7) CONSTRAINT [DF_WebpageContentPermission_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]                  BIT           CONSTRAINT [DF_WebpageContentPermission_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_WebpageContentPermission] PRIMARY KEY CLUSTERED ([WebpageContentPermissionId] ASC),
    CONSTRAINT [FK_WebpageContentPermission_ActiveDirectoryGroup] FOREIGN KEY ([ActiveDirectoryGroupId]) REFERENCES [dbo].[ActiveDirectoryGroup] ([ActiveDirectoryGroupId]),
    CONSTRAINT [FK_WebpageContentPermission_WebpageContent] FOREIGN KEY ([WebpageContentId]) REFERENCES [dbo].[WebpageContent] ([WebpageContentId])
);

