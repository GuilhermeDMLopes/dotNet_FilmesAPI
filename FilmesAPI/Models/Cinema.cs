using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
    //Criando propriedade de relacionamento com Classe Endereco (No caso, o relacionamento é 1:1)
    public int EnderecoId { get; set; }
    //Fazendo o relacionamento 1:1 em si. A entidade cinema possui relação de 1 e apenas 1 Endereco
    //Devemos fazer a mesma coisa em Endereco.cs
    //No momento em que formos cadastrar um cinema, o endereço ja deve existir
    //Quando eu instanciar um novo cinema, tambem preciso instanciar o endereço de forma sincronizada. Para isso utilizamos a Lib MicrosoftEntityFrameWorkCore.Proxies (Na mesma versão da aplicação)
    public virtual Endereco Endereco { get; set; }
    //Fazendo relacionamento tipo 1:n com Sessões
    public virtual ICollection<Sessao> Sessoes { get; set; }
}
