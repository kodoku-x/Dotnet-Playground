using CRUD_ElasticSearch.Models;
using CRUD_ElasticSearch.Services;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("esdemo");
var client = new ElasticClient(settings);

builder.Services.AddSingleton(client);

builder.Services.AddScoped<IElastichsearchServices<Product>, ElasticsearchService<Product>>();

builder.Services.AddControllers();
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
