CREATE TABLE [dbo].[OrderItemModifires] (
    [id]            INT IDENTITY (1, 1) NOT NULL,
    [order_item_id] INT NOT NULL,
    [modifire_id]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([modifire_id]) REFERENCES [dbo].[ItemModifires] ([id]),
    FOREIGN KEY ([order_item_id]) REFERENCES [dbo].[OrderItems] ([id])
);

