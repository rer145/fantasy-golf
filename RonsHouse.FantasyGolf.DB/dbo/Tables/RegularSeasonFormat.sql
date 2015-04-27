CREATE TABLE [dbo].[RegularSeasonFormat] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [TourId]      INT           NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    [IsActive]    BIT           CONSTRAINT [DF_RegularSeasonFormat_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]   DATETIME      CONSTRAINT [DF_RegularSeasonFormat_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]  DATETIME      CONSTRAINT [DF_RegularSeasonFormat_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_RegularSeasonFormat] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RegularSeasonFormat_Tour] FOREIGN KEY ([TourId]) REFERENCES [dbo].[Tour] ([Id])
);

