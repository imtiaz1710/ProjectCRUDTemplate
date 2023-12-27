using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectCRUDTemplate.API.Models.Project.Commands;
using ProjectCRUDTemplate.Core.Entity;
using ProjectCRUDTemplate.Infrustructure.Data;

namespace ProjectCRUDTemplate.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IBaseRepository<Project> baseRepository, IMediator mediator) : ControllerBase
{
    private readonly IBaseRepository<Project> _baseRepository = baseRepository;
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IEnumerable<Project>> Get()
    {

        return await _baseRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand project)
    {
        var response = await _mediator.Send(project);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
