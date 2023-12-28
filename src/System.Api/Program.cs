using Microsoft.EntityFrameworkCore;
using System.Application.Applications;
using System.Domain.Interfaces.ApplicationInterfaces;
using System.Domain.Interfaces.InfrastructureInterfaces;
using System.Infrastructure.Context;
using System.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IInventoryService, InventoryService>();
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddDbContext<ProductContext>(opt => opt.UseSqlServer("Connectionstrings:DefaultConnection"));

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
