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
            throw ex;
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
            throw ex;
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
            throw ex;
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
            throw ex;
        }
        finally
        {
            con.Close();
        }

        return produtos;
    }
}