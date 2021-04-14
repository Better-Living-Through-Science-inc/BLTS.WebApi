CREATE TABLE [dbo].[FileStoragePermission] (
    [FileStoragePermissionId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [FileStorageId]           BIGINT        NOT NULL,
    [ActiveDirectoryGroupId]  BIGINT        NOT NULL,
    [IsEnabled]               BIT           CONSTRAINT [DF_FileStoragePermission_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]            DATETIME2 (7) CONSTRAINT [DF_FileStoragePermission_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]    DATETIME2 (7) CONSTRAINT [DF_FileStoragePermission_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]               BIT           CONSTRAINT [DF_FileStoragePermission_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_FileStoragePermission] PRIMARY KEY CLUSTERED ([FileStoragePermissionId] ASC),
    CONSTRAINT [FK_FileStoragePermission_ActiveDirectoryGroup] FOREIGN KEY ([ActiveDirectoryGroupId]) REFERENCES [dbo].[ActiveDirectoryGroup] ([ActiveDirectoryGroupId]),
    CONSTRAINT [FK_FileStoragePermission_FileStorage] FOREIGN KEY ([FileStorageId]) REFERENCES [dbo].[FileStorage] ([FileStorageId])
);

