CREATE TABLE [dbo].[Golfer] (
    [Id]              INT              IDENTITY (1, 1) NOT NULL,
    [TourId]          INT              NOT NULL,
    [FirstName]       VARCHAR (50)     NOT NULL,
    [LastName]        VARCHAR (50)     NOT NULL,
    [IsActive]        BIT              CONSTRAINT [DF_Golfer_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Golfer_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [SportsDataApiId] UNIQUEIDENTIFIER NULL,
    [LastSyncedOn]    DATETIME         NULL,
    CONSTRAINT [PK_Golfer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Golfer_Tour] FOREIGN KEY ([TourId]) REFERENCES [dbo].[Tour] ([Id])
);

