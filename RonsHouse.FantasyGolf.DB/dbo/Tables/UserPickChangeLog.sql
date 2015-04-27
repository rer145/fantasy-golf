CREATE TABLE [dbo].[UserPickChangeLog] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [UserId]       INT      NOT NULL,
    [TournamentId] INT      NOT NULL,
    [GolferId]     INT      NOT NULL,
    [CreatedOn]    DATETIME CONSTRAINT [DF_UserPickChangeLog_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_UserPickChangeLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPickChangeLog_Golfer] FOREIGN KEY ([GolferId]) REFERENCES [dbo].[Golfer] ([Id]),
    CONSTRAINT [FK_UserPickChangeLog_Tournament] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournament] ([Id]),
    CONSTRAINT [FK_UserPickChangeLog_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

