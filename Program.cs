using api.Controllers;
using api.Data;
using api.Repository.Abstract;
using api.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
 
builder.Services.AddDbContext<MyDbContext>(options =>
        options.UseNpgsql("Host=localhost;Database=Retail;Username=postgres;Password=1234"));
var app = builder.Build();
 
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
});
 
// Configure the HTTP request pipeline.
 
app.UseHttpsRedirection();
 
app.MapControllers();
 
app.Run();