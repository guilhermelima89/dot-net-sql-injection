BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Produto')
BEGIN
    CREATE TABLE [Produto] (
        [Id] int NOT NULL IDENTITY,
        [Descricao] varchar(250) NOT NULL,
        [DataCadastro] datetime NOT NULL,
        [DataAlteracao] datetime NULL,
        CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Teste')
BEGIN
    CREATE TABLE [Teste] (
        [Id] int NOT NULL IDENTITY,
        [Descricao] varchar(250) NOT NULL,
        [DataCadastro] datetime DEFAULT getdate(),       
        CONSTRAINT [PK_Teste] PRIMARY KEY ([Id])
    );
END;
GO

COMMIT;
GO