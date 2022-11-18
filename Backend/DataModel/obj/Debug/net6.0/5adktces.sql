CREATE TABLE [Categoria] (
    [IdCategoria] int NOT NULL IDENTITY,
    [Desc] varchar(100) NULL,
    [DataInclusao] date NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([IdCategoria])
);
GO


CREATE TABLE [Produto] (
    [IdProduto] int NOT NULL IDENTITY,
    [Desc] varchar(100) NULL,
    [Qtd] numeric(4,17) NOT NULL,
    [DataInclusao] date NOT NULL,
    [Vlr] money NOT NULL,
    [IdCategoria] int NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([IdProduto]),
    CONSTRAINT [FK_Produto_Categoria_IdCategoria] FOREIGN KEY ([IdCategoria]) REFERENCES [Categoria] ([IdCategoria]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Produto_IdCategoria] ON [Produto] ([IdCategoria]);
GO


