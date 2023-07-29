//Classe de contexto para a classe de filmes com o banco de dados
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options) :base(options)
    {

    }

    //Relacionamento entre sessao cinema, sessa filme e como o id sera montado
    //sobrescrita de um metodo
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //A entidade sessao vai ter como chave o id do filme e id do cinema.
        builder.Entity<Sessao>()
            .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId});

        //Relacionamento entre as entidades
        //Um sessao vai ter um cinema
        //Um cinema vai ter uma ou mais sessoes
        //A sessao vai ter como chave estrangeira o CinemaId
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);

        //Mesa teoria da construção anterior
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        //Se eu deletar um endereço, as informações de cinema, filme e sessao sera deletadas pelo efeito cascade.
        //Desabilitando cascade
        builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict);

    }

    public DbSet<Filme> Filmes { get; set; }
    //criando DbSet de Cinema
    public DbSet<Cinema> Cinemas { get; set; }
    //criando DbSet de Endereço
    public DbSet<Endereco> Enderecos { get; set; }
    //Criando DbSet de Sessoes
    public DbSet<Sessao> Sessoes { get; set; }
}
