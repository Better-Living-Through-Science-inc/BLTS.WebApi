CREATE TABLE [dbo].[WebsitePermission] (
    [WebsitePermissionId]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [WebsiteInfoId]          BIGINT        NOT NULL,
    [ActiveDirectoryGroupId] BIGINT        NOT NULL,
    [IsEnabled]              BIT           CONSTRAINT [DF_WebsitePermission_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]           DATETIME2 (7) CONSTRAINT [DF_WebsitePermission_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]   DATETIME2 (7) CONSTRAINT [DF_WebsitePermission_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]              BIT           CONSTRAINT [DF_WebsitePermission_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_WebsitePermission] PRIMARY KEY CLUSTERED ([WebsitePermissionId] ASC),
    CONSTRAINT [FK_WebsitePermission_ActiveDirectoryGroup] FOREIGN KEY ([ActiveDirectoryGroupId]) REFERENCES [dbo].[ActiveDirectoryGroup] ([ActiveDirectoryGroupId]),
    CONSTRAINT [FK_WebsitePermission_Website] FOREIGN KEY ([WebsiteInfoId]) REFERENCES [dbo].[WebsiteInfo] ([WebsiteInfoId])
);

