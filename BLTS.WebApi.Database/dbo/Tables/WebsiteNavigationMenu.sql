CREATE TABLE [dbo].[WebsiteNavigationMenu] (
    [WebsiteId]        BIGINT NOT NULL,
    [NavigationMenuId] BIGINT NOT NULL,
    CONSTRAINT [PK_WebsiteNavigationMenu] PRIMARY KEY CLUSTERED ([WebsiteId] ASC, [NavigationMenuId] ASC),
    CONSTRAINT [FK_WebsiteNavigationMenu_NavigationMenu] FOREIGN KEY ([NavigationMenuId]) REFERENCES [dbo].[NavigationMenu] ([NavigationMenuId]),
    CONSTRAINT [FK_WebsiteNavigationMenu_Website] FOREIGN KEY ([WebsiteId]) REFERENCES [dbo].[Website] ([WebsiteId])
);

