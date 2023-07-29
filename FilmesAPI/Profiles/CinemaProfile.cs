using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();        
        CreateMap<UpdateCinemaDto, Cinema>();
        //Para que seja possivel mostrar o Endereço do cinema pelo relacionamento, devemos fazer um mapeamento especifico para Endereço
        //Faremos o mesmo processo anterior para sessao
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco))
            .ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));
    }
}
