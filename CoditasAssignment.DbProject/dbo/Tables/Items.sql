CREATE TABLE [dbo].[Items] (
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [category_id] INT             NULL,
    [name]        NVARCHAR (32)   NOT NULL,
    [price]       DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([category_id]) REFERENCES [dbo].[Categories] ([id])
);

