CREATE TABLE [dbo].[Users] (
    [Id]       INT            NOT NULL,
    [username] NVARCHAR (MAX) NULL,
    [password] NVARCHAR (MAX) NOT NULL,
    [name] NVARCHAR(MAX) NULL, 
    [picture] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

