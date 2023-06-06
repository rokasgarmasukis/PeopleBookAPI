using AutoMapper;

namespace PeopleBookAPI.Profiles;

public class GroupProfile : Profile
{
    public GroupProfile() {
        CreateMap<Entities.Group, Models.GroupDto>();
    }
}
