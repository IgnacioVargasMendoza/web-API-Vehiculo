CREATE TABLE [dbo].[Modelos] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [IdMarca] UNIQUEIDENTIFIER NOT NULL,
    [Nombre]  VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Modelos_Marcas] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marcas] ([Id])
);

