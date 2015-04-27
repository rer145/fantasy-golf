CREATE TABLE [dbo].[TournamentGrouping] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [LeagueId]     INT           NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [DisplayOrder] INT           NOT NULL,
    [IsActive]     BIT           CONSTRAINT [DF_TournamentGrouping_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]    DATETIME      CONSTRAINT [DF_TournamentGrouping_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TournamentGrouping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TournamentGrouping_League] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[League] ([Id])
);

