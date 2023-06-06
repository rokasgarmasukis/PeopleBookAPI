using PeopleBookAPI.Entities;

namespace PeopleBookAPI.Services;

public interface IPeopleBookRepository
{
    Task<IEnumerable<Group>> GetGroupsAsync();
}
