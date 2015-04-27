CREATE TABLE [dbo].[LeagueTournament] (
    [LeagueId]     INT      NOT NULL,
    [TournamentId] INT      NOT NULL,
    [IsActive]     BIT      CONSTRAINT [DF_LeagueTournament_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]    DATETIME CONSTRAINT [DF_LeagueTournament_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_LeagueTournament] PRIMARY KEY CLUSTERED ([LeagueId] ASC, [TournamentId] ASC),
    CONSTRAINT [FK_LeagueTournament_League] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[League] ([Id]),
    CONSTRAINT [FK_LeagueTournament_Tournament] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournament] ([Id])
);

