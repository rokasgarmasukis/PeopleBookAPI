using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    private readonly IPeopleBookRepository _repository;
    private readonly IMapper _mapper;

    public GroupsController(IPeopleBookRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper;
    }


    [HttpGet, Authorize]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
    {
        // implement paging

        var groupEntities = await _repository.GetGroupsAsync();

        return Ok(_mapper.Map<IEnumerable<GroupDto>>(groupEntities));
    }

    [HttpGet("{id}", Name = "GetGroup")]
    public async Task<ActionResult<GroupDto>> GetGroup(int id)
    {

        var groupEntity = await _repository.GetGroupAsync(id);

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

        _repository.AddGroup(groupEntity);

        await _repository.SaveChangesAsync();

        var createdGroupToReturn = _mapper.Map<GroupDto>(groupEntity);

        return CreatedAtRoute("GetGroup", new
        {
            createdGroupToReturn.Id
        },
        createdGroupToReturn);
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult<GroupDto>> UpdateGroup([FromBody] GroupForUpdateDto groupForUpdate )
    //{
    //    // only description update possible?
    //}
}
