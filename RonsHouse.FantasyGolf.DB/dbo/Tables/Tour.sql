CREATE TABLE [dbo].[Tour] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50)  NOT NULL,
    [Website]    VARCHAR (100) NOT NULL,
    [IsActive]   BIT           CONSTRAINT [DF_Tour_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME      CONSTRAINT [DF_Tour_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME      CONSTRAINT [DF_Tour_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED ([Id] ASC)
);

