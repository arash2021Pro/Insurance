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

CREATE TABLE [Permissions] (
    [Id] int NOT NULL IDENTITY,
    [PermissionName] nvarchar(max) NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [RoleName] nvarchar(max) NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [RolePermissions] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [PermissionId] int NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_RolePermissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RolePermissions_Permissions_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Permissions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RolePermissions_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [IsObedient] bit NOT NULL,
    [RoleId] int NOT NULL,
    [NationalCode] nvarchar(max) NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OTP] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [code] nvarchar(max) NOT NULL,
    [IsUsed] bit NOT NULL,
    [ExpireTime] datetimeoffset NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_OTP] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OTP_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_OTP_UserId] ON [OTP] ([UserId]);
GO

CREATE INDEX [IX_RolePermissions_PermissionId] ON [RolePermissions] ([PermissionId]);
GO

CREATE INDEX [IX_RolePermissions_RoleId] ON [RolePermissions] ([RoleId]);
GO

CREATE INDEX [IX_Users_RoleId] ON [Users] ([RoleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220907091536_initial', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] ALTER COLUMN [PhoneNumber] nvarchar(11) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'NationalCode');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Users] ALTER COLUMN [NationalCode] nvarchar(10) NOT NULL;
GO

ALTER TABLE [Users] ADD [UserStatus] int NOT NULL DEFAULT 0;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OTP]') AND [c].[name] = N'code');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [OTP] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [OTP] ALTER COLUMN [code] nvarchar(5) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220907095624_UserStatus', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Logs] (
    [Id] int NOT NULL IDENTITY,
    [BrowserName] nvarchar(max) NULL,
    [Action] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [RoleName] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Logs_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Logs_UserId] ON [Logs] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220911172125_Log', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [Email] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220913120709_Email', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [UserCode] nvarchar(max) NULL;
GO

CREATE TABLE [Plans] (
    [Id] int NOT NULL IDENTITY,
    [Price] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [PlanType] int NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [PlanCount] int NOT NULL,
    [Discount] int NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Plans] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Refferals] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ReferralCount] int NOT NULL DEFAULT 0,
    [PhoneNumber] nvarchar(max) NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Refferals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Refferals_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Wallets] (
    [UserId] int NOT NULL,
    [UsdAmount] real NOT NULL,
    [BtcAmount] real NOT NULL,
    [EthAmount] real NOT NULL,
    [WalletStatus] int NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Wallets] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Wallets_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [PlanId] int NOT NULL,
    [UserId] int NOT NULL,
    [TotalPrice] int NOT NULL,
    [CurrentTime] nvarchar(max) NOT NULL,
    [ModificationTime] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Plans_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [Plans] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Orders_PlanId] ON [Orders] ([PlanId]);
GO

CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
GO

CREATE INDEX [IX_Refferals_UserId] ON [Refferals] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928132047_Plans', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Wallets] ADD [Bonus] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221005120925_Bonus', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Wallets]') AND [c].[name] = N'UsdAmount');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Wallets] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Wallets] ADD DEFAULT CAST(0 AS real) FOR [UsdAmount];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Wallets]') AND [c].[name] = N'EthAmount');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Wallets] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Wallets] ADD DEFAULT CAST(0 AS real) FOR [EthAmount];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Wallets]') AND [c].[name] = N'BtcAmount');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Wallets] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Wallets] ADD DEFAULT CAST(0 AS real) FOR [BtcAmount];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Wallets]') AND [c].[name] = N'Bonus');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Wallets] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Wallets] ADD DEFAULT 0 FOR [Bonus];
GO

ALTER TABLE [Wallets] ADD [CreationTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221005124643_walletupdate', N'6.0.8');
GO

COMMIT;
GO

