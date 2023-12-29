namespace ProjectCRUDTemplate.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IMediator mediator, ILogger<ProjectController> logger) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<ProjectController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Project fetch starting...");

        var response = await _mediator.Send(new GetAllProjectQuery());

        _logger.LogInformation("Successfully fetch the project...");

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand project)
    {
        var response = await _mediator.Send(project);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateProjectCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DeleteProjectCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}
