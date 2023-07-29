namespace FilmesAPI.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    //No momento em que formas retornar um cinema, precisamos retornar também o endereço em que ele se encontra
    public ReadEnderecoDto Endereco { get; private set; }
    //Retornando as sessoes de um cinema. Semelhante ao que fizemos com cinema e endreço
    //Como o relacionamento é 1:n usamos ICollection
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
