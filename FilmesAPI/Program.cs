//Onde definimos os servi�os que usaremos na aplica��o, onde a aplica��o � iniciada, depend�ncias que ela necessita, etc.
using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//variavel de conex�o com banco
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

// Add services to the container.
//Fazendo comunica��o com o banco pegando a String de conex�o em appsettings.json
builder.Services.AddDbContext<FilmeContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//Adicionando AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Adicionando newtonsoft para manipular JSON parao metodo PATCH
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
