﻿CREATE TABLE [dbo].[OperationalConfiguration] (
    [OperationalConfigurationId] BIGINT           IDENTITY (1, 1) NOT NULL,
    [WebsiteId]                  BIGINT           NOT NULL,
    [PropertyName]               NVARCHAR (255)   NOT NULL,
    [Description]                NVARCHAR (512)   NOT NULL,
    [BoolValue]                  BIT              NULL,
    [DateValue]                  DATETIME2 (7)    NULL,
    [DecimalValue]               DECIMAL (28, 10) NULL,
    [GuidValue]                  UNIQUEIDENTIFIER NULL,
    [IntegerValue]               INT              NULL,
    [LongValue]                  BIGINT           NULL,
    [StringValue]                NVARCHAR (MAX)   NULL,
    [IsConnectionString]         BIT              CONSTRAINT [DF_OperationalConfiguration_IsConnectionString] DEFAULT ((0)) NOT NULL,
    [IsEnabled]                  BIT              CONSTRAINT [DF_OperationalConfiguration_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]               DATETIME2 (7)    CONSTRAINT [DF_OperationalConfiguration_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]       DATETIME2 (7)    CONSTRAINT [DF_OperationalConfiguration_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]                  BIT              CONSTRAINT [DF_OperationalConfiguration_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_OperationalConfiguration] PRIMARY KEY CLUSTERED ([OperationalConfigurationId] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = OFF, PAD_INDEX = ON),
    CONSTRAINT [FK_OperationalConfiguration_Website] FOREIGN KEY ([WebsiteId]) REFERENCES [dbo].[Website] ([WebsiteId])
);


GO
ALTER TABLE [dbo].[OperationalConfiguration] SET (LOCK_ESCALATION = AUTO);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_OperationalConfiguration_PropertyName]
    ON [dbo].[OperationalConfiguration]([PropertyName] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = OFF, PAD_INDEX = ON);

