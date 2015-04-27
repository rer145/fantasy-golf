CREATE TABLE [dbo].[Tournament] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [TourId]         INT              NOT NULL,
    [Name]           VARCHAR (200)    NOT NULL,
    [BeginsOn]       DATETIME         NOT NULL,
    [EndsOn]         DATETIME         NOT NULL,
    [IsActive]       BIT              CONSTRAINT [DF_Tournament_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]      DATETIME         CONSTRAINT [DF_Tournament_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [SportDataApiId] UNIQUEIDENTIFIER NULL,
    [LastSyncedOn]   DATETIME         NULL,
    CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tournament_Tour] FOREIGN KEY ([TourId]) REFERENCES [dbo].[Tour] ([Id])
);

