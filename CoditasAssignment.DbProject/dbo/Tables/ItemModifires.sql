CREATE TABLE [dbo].[ItemModifires] (
    [id]      INT             IDENTITY (1, 1) NOT NULL,
    [item_id] INT             NOT NULL,
    [name]    NVARCHAR (32)   NOT NULL,
    [price]   DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([item_id]) REFERENCES [dbo].[Items] ([id])
);

