CREATE TABLE [dbo].[Orders] (
    [id]           INT             IDENTITY (1, 1) NOT NULL,
    [store_id]     INT             NOT NULL,
    [order_number] NVARCHAR (32)   NOT NULL,
    [order_date]   DATETIME        NOT NULL,
    [sub_total]    DECIMAL (18, 2) NOT NULL,
    [tax]          DECIMAL (18, 2) NOT NULL,
    [total]        DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([store_id]) REFERENCES [dbo].[Stores] ([id])
);

