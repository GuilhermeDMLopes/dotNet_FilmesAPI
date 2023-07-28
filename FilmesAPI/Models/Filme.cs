using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    //Colocando id como chave para o banco de dados
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O Título do Filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Gênero do Filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do Gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A Duração do Filme é obrigatória")]
    [Range(70, 300, ErrorMessage = "A duração deve ter entre 70 a 300 minutos")]
    public int Duracao { get; set; }
    
    //Para fazer a migração para o banco de dados, devemos acessar o console do Nuget e enviar o comando: Add-Migration CriandoTabelaDeFilme
    //Para subir as alterações para o banco, usamos o comando: Update-Database
}
