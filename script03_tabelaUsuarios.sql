BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personagens]') AND [c].[name] = N'Nome');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Personagens] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Personagens] ALTER COLUMN [Nome] nvarchar(max) NULL;
GO

ALTER TABLE [Personagens] ADD [fotoPersonagem] varbinary(max) NULL;
GO

ALTER TABLE [Personagens] ADD [usuarioId] int NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Armas]') AND [c].[name] = N'Nome');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Armas] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Armas] ALTER COLUMN [Nome] nvarchar(max) NULL;
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] nvarchar(max) NULL DEFAULT N'Jogador',
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

UPDATE [Personagens] SET [fotoPersonagem] = NULL, [usuarioId] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [fotoPersonagem] = NULL, [usuarioId] = NULL
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [fotoPersonagem] = NULL, [usuarioId] = NULL
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [fotoPersonagem] = NULL, [usuarioId] = NULL
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [fotoPersonagem] = NULL, [usuarioId] = NULL
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [fotoPersonagem] = NULL, [usuarioId] = NULL
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [fotoPersonagem] = NULL, [usuarioId] = NULL
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Perfil], [Username])
VALUES (1, NULL, N'seuEmail@gmail.com', NULL, -23.520024100000001E0, -46.596497999999997E0, 0xF4F18306E40BA1DA9D6601E5EAFD8832EBBD11BE6A828B677764A7B440CF7E60E40E38C61BCECCDEDB5036D50C9357E58A2C1D9C2AF10A73CF3E98AC5630CBE5, 0x069F8D612B136A35ED0F83FE031C532373BF54DF0307A05A69D294C6C6D17687966257C594B9273A4E1BEF71F10797761F001EF50D9FA8AFC76C726DE1EF717812CF6D8007BB27870F9DE98E85D7FAB9F684B8687DC13D0008BB4D027F5C71CDCA3DF8CD056208281D75F53DC0FB55024197A7EEDEF54141816BEF1F8CD24C85, N'Admin', N'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

CREATE INDEX [IX_Personagens_usuarioId] ON [Personagens] ([usuarioId]);
GO

ALTER TABLE [Personagens] ADD CONSTRAINT [FK_Personagens_Usuarios_usuarioId] FOREIGN KEY ([usuarioId]) REFERENCES [Usuarios] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230419001319_MigracaoUsuario', N'7.0.5');
GO

COMMIT;
GO

