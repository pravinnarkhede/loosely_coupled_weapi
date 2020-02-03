CREATE TABLE [dbo].[OrderItems] (
    [id]       INT             IDENTITY (1, 1) NOT NULL,
    [order_id] INT             NOT NULL,
    [item_id]  INT             NOT NULL,
    [price]    DECIMAL (18, 2) NOT NULL,
    [quantity] INT             NOT NULL,
    [total]    DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([item_id]) REFERENCES [dbo].[Items] ([id]),
    FOREIGN KEY ([order_id]) REFERENCES [dbo].[Orders] ([id])
);

