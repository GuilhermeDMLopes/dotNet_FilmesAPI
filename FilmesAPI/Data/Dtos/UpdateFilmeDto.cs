//Classes DTOs são responsaveis por trafegar os dados em diversas camadas para manter integridade do banco de dados
//Classe parecida com a de Filme.cs. No entanto, só conterá as validações que estão sendo feitas e as informações que o usuario deve mandar
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class UpdateFilmeDto
{    
    [Required(ErrorMessage = "O Título do Filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Gênero do Filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do Gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A Duração do Filme é obrigatória")]
    [Range(70, 300, ErrorMessage = "A duração deve ter entre 70 a 300 minutos")]
    public int Duracao { get; set; }
}
