using AutoMapper;

namespace PeopleBookAPI.Profiles;

public class GroupProfile : Profile
{
    public GroupProfile() {
        CreateMap<Entities.Group, Models.GroupDto>();
        CreateMap<Models.GroupForCreationDto, Entities.Group>();
        CreateMap<Models.GroupForUpdateDto, Entities.Group>();
    }
}
