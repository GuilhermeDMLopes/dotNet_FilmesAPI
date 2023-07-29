using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
    //No momento em que criarmos o cinema no banco de dados, precisamos receber como parametro no controlador através do Dto, um EnderecoId
    public int EnderecoId { get; set; }
}
