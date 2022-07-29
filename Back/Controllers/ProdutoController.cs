using Api.Interfaces;
using Api.Models;
using Api.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Produto>> GetAll([FromQuery] QueryStringParameters request)
    {
        return await _produtoRepository.TesteQuatro(request);
    }

    [HttpGet("teste-um")]
    public async Task<IEnumerable<Produto>> TesteUm([FromQuery] string request)
    {
        return await _produtoRepository.TesteUm(request);
    }

    [HttpGet("teste-dois")]
    public async Task<IEnumerable<Produto>> TesteDois([FromQuery] string request)
    {
        return await _produtoRepository.TesteDois(request);
    }

    [HttpGet("teste-tres")]
    public async Task<IEnumerable<Produto>> TesteTres([FromQuery] string request)
    {
        return await _produtoRepository.TesteTres(request);
    }
}