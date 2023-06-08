using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleBookAPI.Services;

namespace PeopleBookAPI.Controllers;

[Route("api/people")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPeopleBookRepository _repository;
    private readonly IMapper _mapper;

    public PeopleController(IPeopleBookRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper;
    }
}
