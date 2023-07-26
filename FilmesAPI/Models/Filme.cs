//Arquivo contendo modelo de objeto Filme para inserirmos no banco
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    public int Id { get; set; }
    //Utilizando Data Annotations do C# para fazer validação dos campos dos dados
    [Required(ErrorMessage = "O Título do Filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Gênero do Filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do Gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A Duração do Filme é obrigatória")]
    [Range(70, 300, ErrorMessage = "A duração deve ter entre 70 a 300 minutos")]
    public int Duracao { get; set; }    
}
