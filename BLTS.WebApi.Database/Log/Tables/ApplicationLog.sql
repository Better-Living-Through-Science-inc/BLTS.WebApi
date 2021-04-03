CREATE TABLE [Log].[ApplicationLog] (
    [ApplicationLogId]     BIGINT          IDENTITY (1, 1) NOT NULL,
    [WebsiteId]            BIGINT          NOT NULL,
    [ApplicationName]      NVARCHAR (255)  NOT NULL,
    [EnvironmentName]      NVARCHAR (255)  NOT NULL,
    [ClassName]            NVARCHAR (255)  NOT NULL,
    [MethodName]           NVARCHAR (255)  NOT NULL,
    [Description]          NVARCHAR (2048) NOT NULL,
    [ExecutionTime]        DATETIME2 (7)   CONSTRAINT [DF_ApplicationLog_ExecutionTime] DEFAULT (sysutcdatetime()) NOT NULL,
    [ExecutionDuration]    BIGINT          CONSTRAINT [DF_ApplicationLog_ExecutionDuration] DEFAULT ((-5555)) NOT NULL,
    [ExceptionStacktrace]  NVARCHAR (4000) NULL,
    [IsException]          BIT             CONSTRAINT [DF_SystemStatusLog_IsException] DEFAULT ((0)) NOT NULL,
    [NotificationDate]     DATETIME2 (7)   CONSTRAINT [DF_SystemStatusLog_EmailNotificationDate] DEFAULT (CONVERT([datetime2](7),'9999-12-31',(0))) NOT NULL,
    [CreationDate]         DATETIME2 (7)   CONSTRAINT [DF_SystemStatusLog_SystemStatusLogDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate] DATETIME2 (7)   CONSTRAINT [DF_SystemStatusLog_CreationDate1] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]            BIT             CONSTRAINT [DF_SystemStatusLog_IsEnabled] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ApplicationLog] PRIMARY KEY CLUSTERED ([ApplicationLogId] ASC, [CreationDate] ASC) ON [DateByMonthPartitionScheme] ([CreationDate]),
    CONSTRAINT [FK_SystemStatusLog_Website] FOREIGN KEY ([WebsiteId]) REFERENCES [dbo].[Website] ([WebsiteId])
) ON [DateByMonthPartitionScheme] ([CreationDate]);


GO
ALTER TABLE [Log].[ApplicationLog] SET (LOCK_ESCALATION = AUTO);

