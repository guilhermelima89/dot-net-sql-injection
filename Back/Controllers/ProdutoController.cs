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

    [HttpGet("teste-quatro")]
    public async Task<IEnumerable<Produto>> TesteQuatro([FromQuery] QueryStringParameters request)
    {
        return await _produtoRepository.TesteQuatro(request);
    }

    [HttpGet("teste-cinco")]
    public async Task<IEnumerable<Produto>> TesteCinco([FromQuery] string request)
    {
        return await _produtoRepository.TesteCinco(request);
    }

    [HttpPost("teste-seis")]
    public async Task<IActionResult> TesteSeis([FromQuery] string request, int id)
    {
        await _produtoRepository.TesteSeis(request, id);

        return Ok();
    }

    [HttpPost("teste-sete")]
    public async Task<IActionResult> TesteSete([FromQuery] string request, string id)
    {
        await _produtoRepository.TesteSete(request, id);

        return Ok();
    }

    [HttpGet("teste-oito")]
    public async Task<IEnumerable<Produto>> TesteOito([FromQuery] string request)
    {
        return await _produtoRepository.TesteOito(request);
    }

    [HttpGet("teste-nove")]
    public async Task<IEnumerable<Produto>> TesteNove([FromQuery] string request)
    {
        return await _produtoRepository.TesteNove(request);
    }

    [HttpGet("teste-dez")]
    public async Task<IEnumerable<Produto>> TesteDez([FromQuery] string request)
    {
        return await _produtoRepository.TesteDez(request);
    }

    [HttpGet("teste-onze")]
    public async Task<IEnumerable<Produto>> TesteOnze([FromQuery] string request)
    {
        return await _produtoRepository.TesteOnze(request);
    }

    [HttpGet("teste-doze")]
    public async Task<IEnumerable<Produto>> TesteDoze([FromQuery] string request)
    {
        return await _produtoRepository.TesteDoze(request);
    }

    [HttpGet("teste-treze")]
    public async Task<IEnumerable<Produto>> TesteTreze([FromQuery] string request)
    {
        return await _produtoRepository.TesteTreze(request);
    }
}