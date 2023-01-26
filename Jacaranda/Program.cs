using Jacaranda.Configuration;
using Jacaranda.Context;
using Jacaranda.External.Repositories;
using Jacaranda.External.Services;
using Jacaranda.UseCase.AdministratorLogin;
using Jacaranda.UseCase.Interfaces;
using Jacaranda.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Secrets.Configure(builder);
JwtConfiguration.Configure(builder);
Repositories.Configure(builder);
Services.Configure(builder);
UseCases.Configure(builder);
Databases.Configure(builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

