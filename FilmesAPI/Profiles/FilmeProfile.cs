//Classe responsável por mostrar ao AutoMapper que ele deve transformar uma DTO em um tipo de classe Filme
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        //AutoMapper pode utilizar o CreateFilmeDto, UpdateFilmeDto, etc..
        //Devemos dar as permissões para que ele atue.
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        //Para o Metodo Patch, devemos permitir que o mapper converta de filme para UpdateFilme
        CreateMap<Filme, UpdateFilmeDto>();
        //Para leitura dos dados
        CreateMap<Filme, ReadFilmeDto>();
    }
}
