using Microsoft.EntityFrameworkCore;
using PeopleBookAPI.DbContexts;
using PeopleBookAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PeopleBookContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:PeopleBookDBConnectionString"]));
builder.Services.AddScoped<IPeopleBookRepository, PeopleBookRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

// recreate & migrate the database on each run, for demo purposes
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<PeopleBookContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();
