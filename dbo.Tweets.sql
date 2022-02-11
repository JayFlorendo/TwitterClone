CREATE TABLE [dbo].[Tweets] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [userId]      INT            NULL,
    [username]    VARCHAR (MAX)  NULL,
    [tweet]       NVARCHAR (MAX) NULL,
    [dateTweeted] DATETIME       NULL,
    [profileName] NVARCHAR (MAX) NULL,
    [picture]     NVARCHAR (MAX) NULL,
    [heart]       INT            NULL DEFAULT 0,
    [retweet]     INT            NULL DEFAULT 0,
    [reply]       INT            NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

