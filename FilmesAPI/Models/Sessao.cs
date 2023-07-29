using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Sessao
{    
    //Fazendo Relação entre um filme e uma sessão. Relacionamento do tipo 1:n (Uma sessao pode ter um filme, mas um filme pode estar em muitas sessoes)
    //Com isso, a relação de dependencia de um para muitos esta do lado da sessao
    //Uma sessao so pode existir com um filme ja criado e associado a essa sessao    
    public int? FilmeId { get; set; }
    //Indicando ao entity que essa relação esta sendo estabelecida
    public virtual Filme Filme { get; set; }
    //Criando Relação entre Cinema e Sessao. Relacionamento também do tipo 1:n (Um Cinema pode ter uma ou mais sessoes, a sessao deve estar em um cinema)
    //Fazemos a mesma coisa que fizemos para filme
    //Para evitar que criemo um CinemaId inexistente quando fizermos a migration, devemos permitir a nulidade deste campo adicionando '?' no tipo da variavel.    
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
    //Faremo um relacionamento entre filmes e cinema do tipo n:n. Para esse tipo de relacionamento precisaremos de uma tabela de relacionamentos
    //No caso, sessão é a tabela de relacionamentos pois possui o FilmeId e CinemaId para identificar em qual cinema esta passando qual filme.
    //Para evitar qualquer tipo de conflito iremos adicionar a nulidade tanto em FilmeId quanto em CinemaId
}
