CREATE TABLE [dbo].[TournamentResult] (
    [TournamentId]   INT   NOT NULL,
    [GolferId]       INT   NOT NULL,
    [Place]          INT   NOT NULL,
    [IsCut]          BIT   CONSTRAINT [DF_TournamentResult_IsCut] DEFAULT ((0)) NOT NULL,
    [IsTied]         BIT   CONSTRAINT [DF_TournamentResult_IsTied] DEFAULT ((0)) NOT NULL,
    [IsDisqualified] BIT   CONSTRAINT [DF_TournamentResult_IsDisqualified] DEFAULT ((0)) NOT NULL,
    [IsWithdrawn]    BIT   CONSTRAINT [DF_TournamentResult_IsWithdrawn] DEFAULT ((0)) NOT NULL,
    [IsPlayoff]      BIT   CONSTRAINT [DF_TournamentResult_IsPlayoff] DEFAULT ((0)) NOT NULL,
    [Winnings]       MONEY CONSTRAINT [DF_TournamentResult_Winnings] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TournamentResult] PRIMARY KEY CLUSTERED ([TournamentId] ASC, [GolferId] ASC),
    CONSTRAINT [FK_TournamentResult_Golfer] FOREIGN KEY ([GolferId]) REFERENCES [dbo].[Golfer] ([Id]),
    CONSTRAINT [FK_TournamentResult_Tournament] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournament] ([Id])
);

