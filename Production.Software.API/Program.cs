using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Production.Software.Application.Handlers.CommandHandlers;
using Production.Software.Core.Repositories;
using Production.Software.Core.Repositories.Base;
using Production.Software.Infrastructure.Data;
using Production.Software.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add AppDbContext
builder.Services.AddDbContext<AppDbContext>(m => 
    m.UseNpgsql(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException()), ServiceLifetime.Singleton);


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(CreateProductHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository < > ), typeof(Repository < > ));
builder.Services.AddTransient < IProductRepository, ProductRepository > ();

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