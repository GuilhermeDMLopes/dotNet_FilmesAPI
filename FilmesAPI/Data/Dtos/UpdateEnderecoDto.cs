using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class UpdateEnderecoDto
{
    [Required(ErrorMessage = "O campo Logradouro é obrigatorio")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O campo Numero é obrigatório")]
    public int Numero { get; set; }
}
