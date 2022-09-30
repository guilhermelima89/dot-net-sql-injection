# SQL INJECTION

## O que é ?

- O SQL Injection é uma técnica de ataque baseada na manipulação do código SQL.
  </br>
  </br>

# Tabelas

## Produto

```SQL
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](250) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produto] ADD  CONSTRAINT [DF_Produto_DataCadastro]  DEFAULT (getdate()) FOR [DataCadastro]
GO
```

## Log

```SQL
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_DataCadastro]  DEFAULT (getdate()) FOR [DataCadastro]
GO
```

#

# Código não seguro

## Exemplo 1

```csharp
public async Task<IEnumerable<Produto>> ObterProdutos(string request)
{
    var connectionString = GetConnection();
    var query = $"SELECT * FROM Produto where Descricao = {request}";

    using (var con = new SqlConnection(connectionString))
    {
        var produtos = await con.QueryAsync<Produto>(query);
        return produtos.ToList();
    }
}
```

- Imput: '' Insert into Log (Descricao) Values ('Pepe Moreno')

```SQL
SELECT * FROM Produto where Descricao = '' Insert into Log (Descricao) Values ('Pepe Moreno')
```

## Exemplo 2

```csharp
public async Task<IEnumerable<Produto>> ObterProdutos(string request)
{
    var connectionString = GetConnection();
    var query = $"SELECT * FROM Produto where Descricao = '" + request + "'";

    using (var con = new SqlConnection(connectionString))
    {
        var produtos = await con.QueryAsync<Produto>(query);
        return produtos.ToList();
    }
}
```

- Imput: '' Insert into Log (Descricao) Values ('Terra Samba')

```SQL
SELECT * FROM Produto where Descricao = '' Insert into Log (Descricao) Values ('Terra Samba')
```

## Outros Exemplos

- ' or ''='
- 1'; Insert into Log (Descricao) Values ('Log') --
- '; Insert into Log (Descricao) Values ('LogT') --
- 1';drop table Log--
- 1';delete Log--
- 1';truncate table Log--\

  </br>

#

# Código seguro

## Exemplo 1

```csharp
public async Task<IEnumerable<Produto>> ObterProdutos(string request)
{
    var connectionString = GetConnection();
    var query = $"SELECT * FROM Produto where Descricao = @descricao";

    var parameters = new DynamicParameters();
    parameters.Add("@descricao", request);

    using (var con = new SqlConnection(connectionString))
    {
        var produtos = await con.QueryAsync<Produto>(query,parameters);
        return produtos.ToList();
    }
}
```

## Exemplo 2

```csharp
public async Task<IEnumerable<Produto>> ObterProdutos(string request)
{
    var connectionString = GetConnection();
    var query = $"SELECT * FROM Produto where Descricao = @descricao";

    using (var con = new SqlConnection(connectionString))
    {
        var produtos = await con.QueryAsync<Produto>(query, new { descricao = request });
        return produtos.ToList();
    }
}
```
