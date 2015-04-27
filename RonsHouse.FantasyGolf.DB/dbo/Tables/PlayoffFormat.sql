CREATE TABLE [dbo].[PlayoffFormat] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [TourId]      INT           NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    [IsActive]    BIT           CONSTRAINT [DF_PlayoffFormat_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]   DATETIME      CONSTRAINT [DF_PlayoffFormat_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]  DATETIME      CONSTRAINT [DF_PlayoffFormat_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PlayoffFormat] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlayoffFormat_Tour] FOREIGN KEY ([TourId]) REFERENCES [dbo].[Tour] ([Id])
);

