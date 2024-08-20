using api.Controllers.Repository;
using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

 builder.Services.AddDbContext<MyDbContext>(options =>
        options.UseNpgsql("Host=localhost;Database=Retail;Username=postgres;Password=1234"));
var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseSwagger();


app.MapControllers();

app.Run();
