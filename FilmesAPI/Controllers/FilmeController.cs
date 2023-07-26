using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

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
    //Inserindo ID nos filmes
    private static int id = 0;

    //Metodo para cadastrar um filme no sistema
    [HttpPost]
    //Como recebemos uma informação do corpo da requisição, precisaremos adicionar o frombody 
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        //Console.WriteLine(filme.Titulo);
        //Console.WriteLine(filme.Duracao);
        //Criando resposta para requisição. Retorna o filme adicionado usando RecuperaFilmePorId para mostrar o endereço do objeto (onde consigo encontra-lo), o id do mesmo e o objeto criado
        //Se observarmos em Header no postman, podemos ver a location de onde encontrar o objeto.
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    //Metodo para ver os filmes no sistema
    [HttpGet]
    //Caso deixemos de utilizar uma lista, colocamos o IEnumerable para que caso utilizemos uma classe Enumerable, não precisemos trocar.
    //Passamos o skip e o take como querys da requisição. Caso não passemos nada, eles serão 0
    public IEnumerable<Filme> RecuperaFilmes( [FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        //Temos a opção de paginar nossa aplicação com o Skip e o Take
        //O Skip consegue pular uma quantidade de dados. Ex: Skip(50) começa a mostrar a partir do id 50
        //Take mostra a quantidade passada por parametro na tela. Ex: Take(5) mostra de 5 em 5.
        return filmes.Skip(skip).Take(take);
    }


    //Metodo para ver filme específico no sistema. Fazemos um bind com {id}. Caso seja passado um parametro id, esse get sera executado. Caso contrario sera executado o get anterior
    [HttpGet("{id}")]
    //Filme pode ser vazio ou não, por isso "Filme?" no tipo de função (se tirar "?" estou afirmando que o resultado não sera nulo)
    //Depois de validar os resultados, devemos mudar o Filme? para IActionResult.
    public IActionResult RecuperaFilmePorId(int id)
    {
        //Retorna primeiro filme ou padrão que possui id passado por parametro
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
