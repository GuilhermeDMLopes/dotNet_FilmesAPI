//Arquivo de um modelo padr�o de uma API base do .NET
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

//Arquivos appsettings s�o os arquivos que cont�m as informa��es que ser�o carregadas durante execu��o da aplica��o
//Endere�o do banco de dados
//Qual � tal senha que queremos carregar, nome de usuario, etc.

//Em properties; launchSettings.json. Temos algums perfis pra nossa aplica��o