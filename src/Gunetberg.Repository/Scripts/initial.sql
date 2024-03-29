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

CREATE TABLE [tags] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Name] nvarchar(30) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_tags] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [users] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Password] nvarchar(200) NOT NULL,
    [Email] nvarchar(150) NOT NULL,
    [Alias] nvarchar(50) NOT NULL,
    [Role] int NOT NULL,
    [PhotoUrl] nvarchar(200) NULL,
    [Description] nvarchar(300) NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [posts] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Language] nvarchar(10) NOT NULL,
    [Title] nvarchar(150) NOT NULL,
    [ImageUrl] nvarchar(4000) NULL,
    [Summary] nvarchar(150) NOT NULL,
    [Content] nvarchar(4000) NOT NULL,
    [CreatedBy] uniqueidentifier NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    CONSTRAINT [PK_posts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_posts_users_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [comments] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Content] nvarchar(250) NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [PostId] uniqueidentifier NOT NULL,
    [CreatedBy] uniqueidentifier NOT NULL,
    [ParentId] uniqueidentifier NULL,
    CONSTRAINT [PK_comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_comments_comments_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [comments] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_comments_posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [posts] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_comments_users_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [post_tags] (
    [PostId] uniqueidentifier NOT NULL,
    [TagId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_post_tags] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_post_tags_posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [posts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_post_tags_tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [tags] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_comments_CreatedBy] ON [comments] ([CreatedBy]);
GO

CREATE INDEX [IX_comments_ParentId] ON [comments] ([ParentId]);
GO

CREATE INDEX [IX_comments_PostId] ON [comments] ([PostId]);
GO

CREATE INDEX [IX_post_tags_TagId] ON [post_tags] ([TagId]);
GO

CREATE INDEX [IX_posts_CreatedBy] ON [posts] ([CreatedBy]);
GO

CREATE UNIQUE INDEX [IX_posts_Title] ON [posts] ([Title]);
GO

CREATE INDEX [IX_users_Id] ON [users] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231101211609_initial', N'7.0.11');
GO

COMMIT;
GO


