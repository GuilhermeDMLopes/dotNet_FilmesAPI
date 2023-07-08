//Arquivo de um modelo padrão de uma API base do .NET
namespace FilmesAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}

//Arquivos appsettings são os arquivos que contém as informações que serão carregadas durante execução da aplicação
//Endereço do banco de dados
//Qual é tal senha que queremos carregar, nome de usuario, etc.

//Em properties; launchSettings.json. Temos algums perfis pra nossa aplicação