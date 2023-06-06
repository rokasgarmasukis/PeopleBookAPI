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

    public async Task<IEnumerable<Group>> GetGroupsAsync()
    {
        return await _context.Groups.OrderBy(g => g.Name).ToListAsync();
    }
}
