using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectCRUDTemplate.API.Models.ProjectCommands;
using ProjectCRUDTemplate.Application.ProjectCommands;
using ProjectCRUDTemplate.Application.ProjectQueries;
using ProjectCRUDTemplate.Core.Entity;
using ProjectCRUDTemplate.Infrustructure.Data;

namespace ProjectCRUDTemplate.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetAllProjectQuery());
        return Ok(response);
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
    public async Task<IActionResult> Delete(DeleteProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
