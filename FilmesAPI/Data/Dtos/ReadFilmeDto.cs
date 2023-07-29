//O que iremos mostrar quando o usuario enviar um GET
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class ReadFilmeDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set;} = DateTime.Now;
    //Retornando as sessoes de um filme. Semelhante ao que fizemos com cinema e endreço
    //Como o relacionamento é 1:n usamos ICollection
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
