using ToDo.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Adicionando os Controllers

var app = builder.Build();
app.MapControllers(); //mapeando os controllers;

app.Run();
