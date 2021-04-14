CREATE TABLE [dbo].[WebsiteNavigationMenu] (
    [WebsiteInfoId]    BIGINT NOT NULL,
    [NavigationMenuId] BIGINT NOT NULL,
    CONSTRAINT [PK_WebsiteNavigationMenu] PRIMARY KEY CLUSTERED ([WebsiteInfoId] ASC, [NavigationMenuId] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = OFF, PAD_INDEX = ON, DATA_COMPRESSION = ROW),
    CONSTRAINT [FK_WebsiteNavigationMenu_NavigationMenu] FOREIGN KEY ([NavigationMenuId]) REFERENCES [dbo].[NavigationMenu] ([NavigationMenuId]),
    CONSTRAINT [FK_WebsiteNavigationMenu_Website] FOREIGN KEY ([WebsiteInfoId]) REFERENCES [dbo].[WebsiteInfo] ([WebsiteInfoId])
);


GO
ALTER TABLE [dbo].[WebsiteNavigationMenu] SET (LOCK_ESCALATION = AUTO);







GO




