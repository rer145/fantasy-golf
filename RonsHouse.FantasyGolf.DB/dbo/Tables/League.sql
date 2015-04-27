CREATE TABLE [dbo].[League] (
    [Id]                    INT           IDENTITY (1, 1) NOT NULL,
    [Name]                  VARCHAR (100) NOT NULL,
    [TourId]                INT           NOT NULL,
    [Season]                INT           NOT NULL,
    [ManagerId]             INT           NOT NULL,
    [BeginsOn]              DATETIME      NULL,
    [EndsOn]                DATETIME      NULL,
    [RegularSeasonFormatId] INT           NOT NULL,
    [PlayoffFormatId]       INT           NOT NULL,
    [IsActive]              BIT           CONSTRAINT [DF_League_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]             DATETIME      CONSTRAINT [DF_League_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_League_Manager] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_League_Tour] FOREIGN KEY ([TourId]) REFERENCES [dbo].[Tour] ([Id])
);

