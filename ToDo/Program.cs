using ToDo.Controllers;
using ToDo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Adicionando os Controllers
builder.Services.AddDbContext<AppDbContext>(); // Adicionando o DbContext como Serviço

var app = builder.Build();
app.MapControllers(); //mapeando os controllers;

app.Run();
