using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleBookAPI.Models;
using PeopleBookAPI.Services;

namespace PeopleBookAPI.Controllers;

[Route("api/groups")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly IPeopleBookRepository _peopleBookRepository;
    private readonly IMapper _mapper;

    public GroupsController (IPeopleBookRepository peopleBookRepository, IMapper mapper)
    {
        _peopleBookRepository = peopleBookRepository ?? throw new ArgumentNullException(nameof(peopleBookRepository));
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
    {
        var groupEntities = await _peopleBookRepository.GetGroupsAsync();

        return Ok(_mapper.Map<IEnumerable<GroupDto>>(groupEntities));
    }
    
}
