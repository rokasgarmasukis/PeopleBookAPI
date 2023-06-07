using Microsoft.EntityFrameworkCore;
using PeopleBookAPI.DbContexts;
using PeopleBookAPI.Entities;

namespace PeopleBookAPI.Services;

public class PeopleBookRepository : IPeopleBookRepository
{
    private readonly PeopleBookContext _context;

    public PeopleBookRepository(PeopleBookContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddGroup(Group group)
    {
        _context.Groups.Add(group);
    }

    public async Task<Group?> GetGroupAsync(int id) => await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);

    public async Task<IEnumerable<Group>> GetGroupsAsync()
    {
        return await _context.Groups.OrderBy(g => g.Name).ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}
