using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
    //Nosso controlador precisa acessar o FilmesContext para ter acesso ao banco de dados
    private FilmeContext _context;
    //Declarando variavel para usar o AutoMapper em Profiles
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    //Substituimos o parametro de classe Filme para DTO para manter as boas práticas. Não deixando nosso banco exposto
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        //É necessário converter um filmeDto para filme. Para isso, utilizaremos a biblioteca AutoMapper
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        //Salvando a adição no banco
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes( [FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    //Metodo PUT
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        //Fazendo a atualização do filme usando Mapper. FilmeDto seja transformado em objeto filme
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        //Retornando status code correto para atualização
        return NoContent();
    }

    //Metodo PATCH. Serve para atualizar campos específicos
    //JsonPatchDocument<UpdateFilmeDto> pode conter uma ou mais informações a um filme que queremos atualizar parcialmente
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        //Para fazer mudanças parciais em JSON, precisaremos da Lib newtonsoft (Microsoft.AspNetCore.Mvc.NewtonSoftJson)
        //Verificando se a informação recebida no patch é valida
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);
        //Se modelo foir invalido
        if(!TryValidateModel(filme))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        //Retornando status code correto para atualização
        return NoContent();

        //Metodo Patch no postman deve ser passado no body de uma maneira especifica
        //"op" é o tipo de operação. No caso do PATCH é replace
        //"path" é o campo que sera atualizado. No exemplo deixado será o titulo, então colocamos "/titulo" (se quisessemos genero "/genero").
        //"value" é o valor que queremos atualizar
    }

    //Criando metodo Delete
    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
