using Microsoft.EntityFrameworkCore;
using PeopleBookAPI.Entities;

namespace PeopleBookAPI.DbContexts;

public class PeopleBookContext : DbContext
{
    public DbSet<User> People { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public PeopleBookContext(DbContextOptions<PeopleBookContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // make username unique

        var groupList = new Group[]
        {
            new Group() {Id = 1, Name = "JavaScript Frontend Programmers", Description = "A place for JS Frontend programmers to share knowledge and news."},
            new Group() {Id = 2, Name = "Node.js Programmers", Description = "A group for JS coders who want to expand their knowlegde to the backend as well.."},
            new Group() {Id = 3, Name = "Dads", Description = "For guys who want to be awesome dads to their kids."}
        };
        modelBuilder.Entity<Group>().HasData(groupList);

        //var userList = new User[]
        //{
        //    new User {Id = 1, UserName = "rokasg", Name = "Rokas"},
        //    new User {Id = 2, UserName = "aline", Name = "Aline"},
        //    new User {Id = 3, UserName = "julian", Name = "Julian"}
        //};

        //modelBuilder.Entity<User>().HasData(userList);
    }

}
