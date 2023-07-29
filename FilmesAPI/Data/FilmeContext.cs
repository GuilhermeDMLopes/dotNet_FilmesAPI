//Classe de contexto para a classe de filmes com o banco de dados
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options) :base(options)
    {

    }

    public DbSet<Filme> Filmes { get; set; }
    //criando DbSet de Cinema
    public DbSet<Cinema> Cinemas { get; set; }
    //criando DbSet de Endereço
    public DbSet<Endereco> Enderecos { get; set; }
}
