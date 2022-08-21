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
    Task TesteSeis(string request, int id);
    Task TesteSete(string request, string id);
    Task<IEnumerable<Produto>> TesteOito(string request);
    Task<IEnumerable<Produto>> TesteNove(string request);
}