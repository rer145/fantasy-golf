CREATE TABLE [dbo].[UserPick] (
    [UserId]       INT      NOT NULL,
    [TournamentId] INT      NOT NULL,
    [GolferId]     INT      NOT NULL,
    [CreatedOn]    DATETIME CONSTRAINT [DF_UserPick_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_UserPick_1] PRIMARY KEY CLUSTERED ([UserId] ASC, [TournamentId] ASC),
    CONSTRAINT [FK_UserPick_Golfer] FOREIGN KEY ([GolferId]) REFERENCES [dbo].[Golfer] ([Id]),
    CONSTRAINT [FK_UserPick_Tournament] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournament] ([Id]),
    CONSTRAINT [FK_UserPick_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



