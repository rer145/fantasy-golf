CREATE TABLE [dbo].[User] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [Email]     VARCHAR (80) NOT NULL,
    [IsActive]  BIT          CONSTRAINT [DF_User_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn] DATETIME     CONSTRAINT [DF_User_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

