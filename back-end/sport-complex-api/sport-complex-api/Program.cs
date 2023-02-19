using MediatR;
using Microsoft.EntityFrameworkCore;
using sport_complex_api.Infastructure.Database.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddDbContext<CommonContext>(options =>
                options.UseSqlServer("Database=sportcomplex;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"));

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
