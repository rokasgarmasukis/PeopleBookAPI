using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleBookAPI.Entities;
using PeopleBookAPI.Models;
using PeopleBookAPI.Services;

namespace PeopleBookAPI.Controllers;

[Route("api/groups")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly IPeopleBookRepository _peopleBookRepository;
    private readonly IMapper _mapper;

    public GroupsController(IPeopleBookRepository peopleBookRepository, IMapper mapper)
    {
        _peopleBookRepository = peopleBookRepository ?? throw new ArgumentNullException(nameof(peopleBookRepository));
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
    {
        // implement paging

        var groupEntities = await _peopleBookRepository.GetGroupsAsync();

        return Ok(_mapper.Map<IEnumerable<GroupDto>>(groupEntities));
    }

    [HttpGet("{id}", Name = "GetGroup")]
    public async Task<ActionResult<GroupDto>> GetGroup(int id)
    {

        var groupEntity = await _peopleBookRepository.GetGroupAsync(id);

        if (groupEntity == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<GroupDto>(groupEntity));
    }

    [HttpPost]
    public async Task<ActionResult<GroupDto>> CreateGroup([FromBody] GroupForCreationDto groupForCreation)
    {
        var groupEntity = _mapper.Map<Group>(groupForCreation);

        _peopleBookRepository.AddGroup(groupEntity);

        await _peopleBookRepository.SaveChangesAsync();

        var createdGroupToReturn = _mapper.Map<GroupDto>(groupEntity);

        return CreatedAtRoute("GetGroup", new
        {
            createdGroupToReturn.Id
        },
        createdGroupToReturn);
    }


}
