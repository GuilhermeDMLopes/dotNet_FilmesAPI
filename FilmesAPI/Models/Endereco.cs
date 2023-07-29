using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Logradouro é obrigatorio")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O campo Numero é obrigatório")]
    public int Numero { get; set; }
    //Criando propriedade de relacionamento com Classe Cinema (No caso, o relacionamento é 1:1)
    //public int CinemaId { get; set; }
    //Por que a linha acima esta comentada? Pois o Endereço pode existir sem um Cinema, mas um Cinema não pode existir sem um endereço
    //Fazendo o relacionamento 1:1 em si. A entidade Endereco possui relação de 1 e apenas 1 Cinema
    //Devemos fazer a mesma coisa em Cinema.cs
    public virtual Cinema Cinema { get; set; }

}
