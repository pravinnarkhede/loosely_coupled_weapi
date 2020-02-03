CREATE TABLE [dbo].[StoreCategories] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [store_id]    INT NULL,
    [category_id] INT NULL,
    [is_active]   BIT DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([category_id]) REFERENCES [dbo].[Categories] ([id]),
    FOREIGN KEY ([store_id]) REFERENCES [dbo].[Stores] ([id])
);

