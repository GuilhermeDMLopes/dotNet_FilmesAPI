using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

//Adicionando especificações para uma classe controller
[ApiController]
//Configurando rota para este controlador
[Route("[controller]")]

//Extendendo do ControllerBase para pegar funções de controladores
public class FilmeController : ControllerBase
{
    //Criando uma lista de filmes
    private static List<Filme> filmes = new List<Filme>();

    //Metodo para cadastrar um filme no sistema
    [HttpPost]
    //Como recebemos uma informação do corpo da requisição, precisaremos adicionar o frombody 
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }
}
