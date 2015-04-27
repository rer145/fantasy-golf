CREATE TABLE [dbo].[LeagueTournamentGrouping] (
    [TournamentGroupingId] INT      NOT NULL,
    [TournamentId]         INT      NOT NULL,
    [IsActive]             BIT      CONSTRAINT [DF_LeagueTournamentGrouping_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]            DATETIME CONSTRAINT [DF_LeagueTournamentGrouping_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_LeagueTournamentGrouping] PRIMARY KEY CLUSTERED ([TournamentGroupingId] ASC, [TournamentId] ASC),
    CONSTRAINT [FK_LeagueTournamentGrouping_Tournament] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournament] ([Id]),
    CONSTRAINT [FK_LeagueTournamentGrouping_TournamentGrouping] FOREIGN KEY ([TournamentGroupingId]) REFERENCES [dbo].[TournamentGrouping] ([Id])
);

