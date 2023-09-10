using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controller;

[ApiController]
[Route("[controller]")]

public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _maper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _maper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _maper.Map<Endereco>(enderecoDto);
        _context.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaEnderecoId), new { Id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> BuscaEnderecos()
    {
        return _maper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult? BuscaEnderecoId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        var enderecoDto = _maper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, UpdateCinemaDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _maper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaEnderecoParcial(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        var enderecoAtualiza = _maper.Map<UpdateEnderecoDto>(endereco);
        patch.ApplyTo(enderecoAtualiza, ModelState);

        if (!TryValidateModel(enderecoAtualiza))
        {
            return ValidationProblem(ModelState);
        }
        _maper.Map(enderecoAtualiza, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}