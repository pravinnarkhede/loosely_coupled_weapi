CREATE TABLE [dbo].[Stores] (
    [id]      INT            IDENTITY (1, 1) NOT NULL,
    [name]    NVARCHAR (64)  NOT NULL,
    [city]    NVARCHAR (32)  NULL,
    [address] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

