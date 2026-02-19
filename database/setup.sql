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
CREATE TABLE [Category] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([ID])
);

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Role] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

CREATE TABLE [Product] (
    [ID] int NOT NULL IDENTITY,
    [CategoryID] int NOT NULL,
    [Brand] nvarchar(max) NOT NULL,
    [Model] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ImageUrl] nvarchar(max) NOT NULL,
    [RequiresApproval] bit NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Product_Category_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Category] ([ID]) ON DELETE CASCADE
);

CREATE TABLE [Unit] (
    [ID] int NOT NULL IDENTITY,
    [ProductID] int NOT NULL,
    [SerialNumber] nvarchar(max) NULL,
    [Tag] nvarchar(max) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Unit] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Unit_Product_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Product] ([ID]) ON DELETE CASCADE
);

CREATE TABLE [Booking] (
    [ID] int NOT NULL IDENTITY,
    [UserID] int NOT NULL,
    [ProductID] int NOT NULL,
    [UnitID] int NOT NULL,
    [ApprovedByUserID] int NOT NULL,
    [ScheduledStart] datetime2 NOT NULL,
    [ScheduledEnd] datetime2 NOT NULL,
    [PickedUpAt] datetime2 NOT NULL,
    [ReturnedAt] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Booking] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Booking_Product_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Product] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Booking_Unit_UnitID] FOREIGN KEY ([UnitID]) REFERENCES [Unit] ([ID]),
    CONSTRAINT [FK_Booking_User_UserID] FOREIGN KEY ([UserID]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Maintenance] (
    [ID] int NOT NULL IDENTITY,
    [CreatedByUserID] int NOT NULL,
    [ClosedByUserID] int NOT NULL,
    [UnitID] int NOT NULL,
    [Reason] nvarchar(max) NOT NULL,
    [Notes] nvarchar(max) NOT NULL,
    [Start] datetime2 NOT NULL,
    [End] datetime2 NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Maintenance] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Maintenance_Unit_UnitID] FOREIGN KEY ([UnitID]) REFERENCES [Unit] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Maintenance_User_ClosedByUserID] FOREIGN KEY ([ClosedByUserID]) REFERENCES [User] ([Id]),
    CONSTRAINT [FK_Maintenance_User_CreatedByUserID] FOREIGN KEY ([CreatedByUserID]) REFERENCES [User] ([Id])
);

CREATE INDEX [IX_Booking_ProductID] ON [Booking] ([ProductID]);

CREATE INDEX [IX_Booking_UnitID] ON [Booking] ([UnitID]);

CREATE INDEX [IX_Booking_UserID] ON [Booking] ([UserID]);

CREATE INDEX [IX_Maintenance_ClosedByUserID] ON [Maintenance] ([ClosedByUserID]);

CREATE INDEX [IX_Maintenance_CreatedByUserID] ON [Maintenance] ([CreatedByUserID]);

CREATE INDEX [IX_Maintenance_UnitID] ON [Maintenance] ([UnitID]);

CREATE INDEX [IX_Product_CategoryID] ON [Product] ([CategoryID]);

CREATE INDEX [IX_Unit_ProductID] ON [Unit] ([ProductID]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260219082922_InitialCreate', N'10.0.3');

COMMIT;
GO

