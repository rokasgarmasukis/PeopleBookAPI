using Microsoft.EntityFrameworkCore;
using PeopleBookAPI.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<PeopleBookContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:PeopleBookDBConnectionString"]));

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
