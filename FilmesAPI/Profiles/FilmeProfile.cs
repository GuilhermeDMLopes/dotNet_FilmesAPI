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
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
