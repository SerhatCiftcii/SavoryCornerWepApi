using FluentValidation;
using SavoryCorner.WebApi.Context;
using SavoryCorner.WebApi.Entites;
using SavoryCorner.WebApi.ValidationRules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>();//api context ctor olarak kullanýlýyor mesajý
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());// auotomapper için gerekli olan assembly'i ekliyoruz

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();//FluentValidation için gerekli olan validator'u ekliyoruz

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
