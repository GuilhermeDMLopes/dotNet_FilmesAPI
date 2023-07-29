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
        CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto => cinemaDto.ReadEnderecoDto, opt => opt.MapFrom(cinema => cinema.Endereco));
    }
}
