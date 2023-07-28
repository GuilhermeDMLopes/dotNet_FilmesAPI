//Onde definimos os serviços que usaremos na aplicação, onde a aplicação é iniciada, dependências que ela necessita, etc.
using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//variavel de conexão com banco
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

// Add services to the container.
//Fazendo comunicação com o banco pegando a String de conexão em appsettings.json
builder.Services.AddDbContext<FilmeContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//Adicionando AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Adicionando newtonsoft para manipular JSON parao metodo PATCH
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Adicionando configuração para swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
