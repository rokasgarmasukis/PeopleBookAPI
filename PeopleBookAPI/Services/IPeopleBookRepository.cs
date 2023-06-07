using PeopleBookAPI.Entities;

namespace PeopleBookAPI.Services;

public interface IPeopleBookRepository
{
    Task<IEnumerable<Group>> GetGroupsAsync();
    Task<Group?> GetGroupAsync(int id);
    void AddGroup(Group group);
    Task<bool> SaveChangesAsync();
}
