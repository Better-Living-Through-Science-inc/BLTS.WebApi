﻿CREATE TABLE [dbo].[ApplicationInfo] (
    [ApplicationInfoId]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]                    NVARCHAR (255) NOT NULL,
    [Version]                 NVARCHAR (255) NOT NULL,
    [Title]                   NVARCHAR (255) NOT NULL,
    [Description]             NVARCHAR (255) NOT NULL,
    [PocEmail]                NVARCHAR (255) NULL,
    [PocNumber]               NVARCHAR (255) NULL,
    [IsAuthorizationRequired] BIT            CONSTRAINT [DF_Application_IsAuthorizationRequired] DEFAULT ((0)) NOT NULL,
    [IsEnabled]               BIT            CONSTRAINT [DF_Application_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]            DATETIME2 (7)  CONSTRAINT [DF_Application_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]    DATETIME2 (7)  CONSTRAINT [DF_Application_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF_Application_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED ([ApplicationInfoId] ASC) WITH (FILLFACTOR = 90)
);

