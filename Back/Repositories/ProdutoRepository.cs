using System.Text;
using Api.Interfaces;
using Api.Models;
using Api.Pagination;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Api.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly IConfiguration _configuration;
    public ProdutoRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnection()
    {
        var connection = _configuration.GetSection("ConnectionStrings").GetSection("ApplicationDbContext").Value;
        return connection;
    }

    public async Task<IEnumerable<Produto>> TesteUm(string request)
    {
        var connectionString = this.GetConnection();
        List<Produto> produtos = new List<Produto>();
        await using var con = new SqlConnection(connectionString);

        try
        {
            con.Open();
            var query = "SELECT * FROM Produto where descricao = '" + request + "'";
            produtos = con.Query<Produto>(query).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }

    public async Task<IEnumerable<Produto>> TesteDois(string request)
    {
        var connectionString = this.GetConnection();
        List<Produto> produtos = new List<Produto>();
        await using var con = new SqlConnection(connectionString);

        try
        {
            con.Open();
            var query = "SELECT * FROM Produto where id = " + request;
            produtos = con.Query<Produto>(query).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }

    public async Task<IEnumerable<Produto>> TesteTres(string request)
    {
        var connectionString = this.GetConnection();
        List<Produto> produtos = new List<Produto>();
        await using var con = new SqlConnection(connectionString);

        try
        {
            con.Open();
            var query = $"SELECT * FROM Produto where id = '{request}'";
            produtos = con.Query<Produto>(query).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }

    public async Task<IEnumerable<Produto>> TesteQuatro(QueryStringParameters request)
    {
        var connectionString = this.GetConnection();
        List<Produto> produtos = new List<Produto>();
        await using var con = new SqlConnection(connectionString);
        try
        {
            con.Open();
            var query = $"SELECT * FROM Produto where Descricao like '%" + request.Query + "%'";
            produtos = con.Query<Produto>(query).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }

    public async Task<IEnumerable<Produto>> TesteCinco(string request)
    {
        var connectionString = this.GetConnection();
        List<Produto> produtos = new List<Produto>();
        await using var con = new SqlConnection(connectionString);

        try
        {
            con.Open();
            var query = new StringBuilder();
            query.Append("SELECT * FROM Produto ");
            query.Append($"where id = '{request}'");

            produtos = con.Query<Produto>(query.ToString()).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }
    public async Task TesteSeis(string request, int id)
    {
        var connectionString = this.GetConnection();
        await using var con = new SqlConnection(connectionString);

        try
        {
            con.Open();
            var query = $"update Produto set Descricao =  '{request}' WHERE ID = {id}";
            con.Execute(query);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return;
    }

    public async Task TesteSete(string request, string id)
    {
        var connectionString = this.GetConnection();
        await using var con = new SqlConnection(connectionString);

        try
        {
            con.Open();
            var query = @$"update Produto 
                            set Descricao =  '{request}' 
                            WHERE ID = {id}";
            con.Execute(query);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return;
    }

    public async Task<IEnumerable<Produto>> TesteOito(string request)
    {
        var connectionString = this.GetConnection();
        List<Produto> produtos = new List<Produto>();
        await using var con = new SqlConnection(connectionString);

        try
        {
            con.Open();
            var query = $"SELECT * FROM Produto where Descricao = @descricao";
            produtos = con.Query<Produto>(query, new { descricao = request }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }

    public async Task<IEnumerable<Produto>> TesteNove(string request)
    {
        var connectionString = this.GetConnection();
        List<Produto> produtos = new List<Produto>();
        await using var con = new SqlConnection(connectionString);

        var parameters = new DynamicParameters();
        parameters.Add("@descricao", request);

        try
        {
            con.Open();
            var query = $"SELECT * FROM Produto where Descricao = @descricao";
            produtos = con.Query<Produto>(query, parameters).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }
}