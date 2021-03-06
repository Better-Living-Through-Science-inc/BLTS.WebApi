﻿CREATE TABLE [dbo].[WebsiteInfo] (
    [WebsiteInfoId]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [ApplicationInfoId]       BIGINT         NOT NULL,
    [Name]                    NVARCHAR (255) NOT NULL,
    [Metatag]                 NVARCHAR (255) NOT NULL,
    [Title]                   NVARCHAR (255) NOT NULL,
    [Description]             NVARCHAR (255) NOT NULL,
    [Footer]                  NVARCHAR (MAX) NOT NULL,
    [BaseUrl]                 NVARCHAR (255) NOT NULL,
    [CssThemePath]            NVARCHAR (255) NULL,
    [IsAuthorizationRequired] BIT            CONSTRAINT [DF_Website_IsAuthorizationRequired] DEFAULT ((0)) NOT NULL,
    [IsEnabled]               BIT            CONSTRAINT [DF_Website_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]            DATETIME2 (7)  CONSTRAINT [DF_Website_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]    DATETIME2 (7)  CONSTRAINT [DF_Website_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF_Website_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Website] PRIMARY KEY CLUSTERED ([WebsiteInfoId] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Website_Application] FOREIGN KEY ([ApplicationInfoId]) REFERENCES [dbo].[ApplicationInfo] ([ApplicationInfoId])
);

