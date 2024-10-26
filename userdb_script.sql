CREATE DATABASE [db_user]
GO

USE [db_user]
GO

CREATE TABLE [dbo].[Users] (
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL, 
    [Created] DATETIME2(7) NOT NULL,
    [Modified] DATETIME2(7) NOT NULL,
    [LastLogin] DATETIME2(7) NULL,
    [Token] NVARCHAR(255) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE UNIQUE INDEX [IX_Users_Email] ON [dbo].[Users] ([Email] ASC)
GO

CREATE TABLE [dbo].[Phones] (
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [CountryCode] NVARCHAR(10) NOT NULL,
    [CityCode] NVARCHAR(10) NOT NULL,
    [Number] NVARCHAR(20) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Phones_Users_UserId] FOREIGN KEY ([UserId])
        REFERENCES [dbo].[Users] ([Id])
        ON DELETE CASCADE
)
