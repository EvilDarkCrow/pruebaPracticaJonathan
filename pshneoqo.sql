IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [members] (
    [id] bigint NOT NULL IDENTITY,
    [name] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_members] PRIMARY KEY ([id])
);
GO

CREATE TABLE [products] (
    [Id] bigint NOT NULL IDENTITY,
    [name] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [orders] (
    [id] bigint NOT NULL IDENTITY,
    [dateOrder] datetime2 NOT NULL,
    [MemberId] bigint NOT NULL,
    [ProductId] bigint NOT NULL,
    CONSTRAINT [PK_orders] PRIMARY KEY ([id]),
    CONSTRAINT [FK_orders_members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [members] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_orders_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_orders_MemberId] ON [orders] ([MemberId]);
GO

CREATE INDEX [IX_orders_ProductId] ON [orders] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240412064644_goodDB', N'8.0.4');
GO

COMMIT;
GO

