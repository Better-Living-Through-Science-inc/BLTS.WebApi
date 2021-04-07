CREATE TABLE [dbo].[NavigationMenuNavigationMenu] (
    [ParentNavigationMenuId] BIGINT NOT NULL,
    [ChildNavigationMenuId]  BIGINT NOT NULL,
    CONSTRAINT [PK_NavigationMenuNavigationMenu] PRIMARY KEY CLUSTERED ([ParentNavigationMenuId] ASC, [ChildNavigationMenuId] ASC) WITH (FILLFACTOR = 90, ALLOW_PAGE_LOCKS = OFF, PAD_INDEX = ON, DATA_COMPRESSION = ROW),
    CONSTRAINT [FK_NavigationMenuNavigationMenu_NavigationMenu] FOREIGN KEY ([ParentNavigationMenuId]) REFERENCES [dbo].[NavigationMenu] ([NavigationMenuId]),
    CONSTRAINT [FK_NavigationMenuNavigationMenu_NavigationMenu1] FOREIGN KEY ([ChildNavigationMenuId]) REFERENCES [dbo].[NavigationMenu] ([NavigationMenuId])
);


GO
ALTER TABLE [dbo].[NavigationMenuNavigationMenu] SET (LOCK_ESCALATION = AUTO);



