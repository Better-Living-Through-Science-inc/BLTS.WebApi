CREATE TABLE [dbo].[ApplicationPermission] (
    [ApplicationPermissionId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [ApplicationInfoId]       BIGINT        NOT NULL,
    [ActiveDirectoryGroupId]  BIGINT        NOT NULL,
    [IsEnabled]               BIT           CONSTRAINT [DF_ApplicationPermission_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]            DATETIME2 (7) CONSTRAINT [DF_ApplicationPermission_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]    DATETIME2 (7) CONSTRAINT [DF_ApplicationPermission_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]               BIT           CONSTRAINT [DF_ApplicationPermission_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ApplicationPermission] PRIMARY KEY CLUSTERED ([ApplicationPermissionId] ASC),
    CONSTRAINT [FK_ApplicationPermission_ActiveDirectoryGroup] FOREIGN KEY ([ActiveDirectoryGroupId]) REFERENCES [dbo].[ActiveDirectoryGroup] ([ActiveDirectoryGroupId]),
    CONSTRAINT [FK_ApplicationPermission_Application] FOREIGN KEY ([ApplicationInfoId]) REFERENCES [dbo].[ApplicationInfo] ([ApplicationInfoId])
);

