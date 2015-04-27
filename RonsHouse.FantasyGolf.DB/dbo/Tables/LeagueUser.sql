CREATE TABLE [dbo].[LeagueUser] (
    [LeagueId]  INT      NOT NULL,
    [UserId]    INT      NOT NULL,
    [IsActive]  BIT      CONSTRAINT [DF_LeagueUser_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn] DATETIME CONSTRAINT [DF_LeagueUser_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_LeagueUser] PRIMARY KEY CLUSTERED ([LeagueId] ASC, [UserId] ASC),
    CONSTRAINT [FK_LeagueUser_League] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[League] ([Id]),
    CONSTRAINT [FK_LeagueUser_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

