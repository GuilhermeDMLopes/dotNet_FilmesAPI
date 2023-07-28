//O que iremos mostrar quando o usuario enviar um GET
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class ReadFilmeDto
{
    //Não precisa de validações para metodos de apenas leitura de dados
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    //Informação que pertence apenas ao escopo do Dto
    public DateTime HoraDaConsulta { get; set;} = DateTime.Now;
}
