//Classe de contexto para a classe de filmes com o banco de dados
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

//Extende de Dbcontext 
public class FilmeContext : DbContext
{
    //Gerando construtor
    //Recebe as opções de acesso ao banco como parametro
    public FilmeContext(DbContextOptions<FilmeContext> options) :base(options)
    {

    }

    //Propriedade de acesso aos filmes na nossa base. Ela conterá nossos filmes
    public DbSet<Filme> Filmes { get; set; }
}
