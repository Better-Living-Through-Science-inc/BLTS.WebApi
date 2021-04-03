CREATE TABLE [dbo].[NavigationMenuNavigationMenu] (
    [ParentNavigationMenuId] BIGINT NOT NULL,
    [ChildNavigationMenuId]  BIGINT NOT NULL,
    CONSTRAINT [PK_NavigationMenuNavigationMenu] PRIMARY KEY CLUSTERED ([ParentNavigationMenuId] ASC, [ChildNavigationMenuId] ASC),
    CONSTRAINT [FK_NavigationMenuNavigationMenu_NavigationMenu] FOREIGN KEY ([ParentNavigationMenuId]) REFERENCES [dbo].[NavigationMenu] ([NavigationMenuId]),
    CONSTRAINT [FK_NavigationMenuNavigationMenu_NavigationMenu1] FOREIGN KEY ([ChildNavigationMenuId]) REFERENCES [dbo].[NavigationMenu] ([NavigationMenuId])
);

