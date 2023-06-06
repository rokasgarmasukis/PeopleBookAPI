using Microsoft.EntityFrameworkCore;
using PeopleBookAPI.Entities;

namespace PeopleBookAPI.DbContexts;

public class PeopleBookContext : DbContext
{
    public DbSet<User> People { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Post> Posts { get; set; }

    public PeopleBookContext(DbContextOptions<PeopleBookContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}
