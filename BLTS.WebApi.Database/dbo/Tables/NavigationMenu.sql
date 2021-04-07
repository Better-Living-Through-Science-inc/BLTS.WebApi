CREATE TABLE [dbo].[NavigationMenu] (
    [NavigationMenuId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [WebpageContentId]        BIGINT         NOT NULL,
    [DisplayText]             NVARCHAR (255) NOT NULL,
    [ToolTip]                 NVARCHAR (255) NOT NULL,
    [SubPath]                 NVARCHAR (255) NOT NULL,
    [IconClass]               NVARCHAR (255) NOT NULL,
    [IsAuthorizationRequired] BIT            CONSTRAINT [DF_NavigationMenu_IsRequiresAuthorization] DEFAULT ((0)) NOT NULL,
    [IsEnabled]               BIT            CONSTRAINT [DF_NavigationMenu_IsEnabled] DEFAULT ((1)) NOT NULL,
    [CreationDate]            DATETIME2 (7)  CONSTRAINT [DF_NavigationMenu_CreationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [LastModificationDate]    DATETIME2 (7)  CONSTRAINT [DF_NavigationMenu_LastModificationDate] DEFAULT (sysutcdatetime()) NOT NULL,
    [IsDeleted]               BIT            CONSTRAINT [DF_NavigationMenu_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_NavigationMenu] PRIMARY KEY CLUSTERED ([NavigationMenuId] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = OFF, PAD_INDEX = ON, DATA_COMPRESSION = ROW),
    CONSTRAINT [FK_NavigationMenu_WebpageContent] FOREIGN KEY ([WebpageContentId]) REFERENCES [dbo].[WebpageContent] ([WebpageContentId])
);


GO
ALTER TABLE [dbo].[NavigationMenu] SET (LOCK_ESCALATION = AUTO);



