namespace FilmesAPI.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    //No momento em que formas retornar um cinema, precisamos retornar também o endereço em que ele se encontra
    public ReadEnderecoDto ReadEnderecoDto { get; private set; }
}
