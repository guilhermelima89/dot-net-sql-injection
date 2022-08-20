using Api.Models;
using Api.Pagination;

namespace Api.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> TesteUm(string request);
    Task<IEnumerable<Produto>> TesteDois(string request);
    Task<IEnumerable<Produto>> TesteTres(string request);
    Task<IEnumerable<Produto>> TesteQuatro(QueryStringParameters request);
    Task<IEnumerable<Produto>> TesteCinco(string request);
    Task<IEnumerable<Produto>> TesteSeis(string request);
}