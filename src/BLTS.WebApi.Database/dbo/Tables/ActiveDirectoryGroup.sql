CREATE TABLE [dbo].[ActiveDirectoryGroup] (
    [ActiveDirectoryGroupId] BIGINT           IDENTITY (1, 1) NOT NULL,
    [Name]                   NVARCHAR (255)   NOT NULL,
    [GroupSid]               UNIQUEIDENTIFIER NOT NULL,
    [LastModificationDate]   DATETIME2 (7)    CONSTRAINT [DF_ActiveDirectoryGroup_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [CreationDate]           DATETIME2 (7)    CONSTRAINT [DF_ActiveDirectoryGroup_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]              BIT              CONSTRAINT [DF_ActiveDirectoryGroup_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ActiveDirectoryGroup] PRIMARY KEY CLUSTERED ([ActiveDirectoryGroupId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_ActiveDirectoryGroup]
    ON [dbo].[ActiveDirectoryGroup]([GroupSid] ASC);

