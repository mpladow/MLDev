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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034238_initial-migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230209034238_initial-migration', N'7.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    IF SCHEMA_ID(N'LOTOW') IS NULL EXEC(N'CREATE SCHEMA [LOTOW];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    CREATE TABLE [LOTOW].[Characters] (
        [CharacterId] int NOT NULL IDENTITY,
        [Name] varchar(200) NOT NULL,
        [Level] decimal(14,2) NOT NULL,
        [Cost] decimal(14,2) NOT NULL,
        CONSTRAINT [PK_Characters] PRIMARY KEY ([CharacterId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    CREATE TABLE [LOTOW].[Stats] (
        [StatId] int NOT NULL IDENTITY,
        [Order] decimal(18,2) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [IsFinite] bit NOT NULL,
        CONSTRAINT [PK_Stats] PRIMARY KEY ([StatId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    CREATE TABLE [LOTOW].[CharacterStats] (
        [CharacterStatId] int NOT NULL IDENTITY,
        [StatId] int NOT NULL,
        [CharacterId] int NOT NULL,
        [InitialValue] int NOT NULL,
        [CurrentValue] int NOT NULL,
        CONSTRAINT [PK_CharacterStats] PRIMARY KEY ([CharacterStatId]),
        CONSTRAINT [FK_CharacterStats_Characters_CharacterId] FOREIGN KEY ([CharacterId]) REFERENCES [LOTOW].[Characters] ([CharacterId]) ON DELETE CASCADE,
        CONSTRAINT [FK_CharacterStats_Stats_StatId] FOREIGN KEY ([StatId]) REFERENCES [LOTOW].[Stats] ([StatId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    CREATE TABLE [LOTOW].[StatModifiers] (
        [StatModifierId] int NOT NULL IDENTITY,
        [Value] int NOT NULL,
        [SourceDescription] nvarchar(max) NOT NULL,
        [CharacterStatId] int NULL,
        CONSTRAINT [PK_StatModifiers] PRIMARY KEY ([StatModifierId]),
        CONSTRAINT [FK_StatModifiers_CharacterStats_CharacterStatId] FOREIGN KEY ([CharacterStatId]) REFERENCES [LOTOW].[CharacterStats] ([CharacterStatId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    CREATE INDEX [IX_CharacterStats_CharacterId] ON [LOTOW].[CharacterStats] ([CharacterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    CREATE INDEX [IX_CharacterStats_StatId] ON [LOTOW].[CharacterStats] ([StatId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    CREATE INDEX [IX_StatModifiers_CharacterStatId] ON [LOTOW].[StatModifiers] ([CharacterStatId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209034955_initial-migration2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230209034955_initial-migration2', N'7.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230209233904_mssql.azure_migration_512')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230209233904_mssql.azure_migration_512', N'7.0.2');
END;
GO

COMMIT;
GO

