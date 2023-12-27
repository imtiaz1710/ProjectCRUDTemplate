using MediatR;
using ProjectCRUDTemplate.Application.Common;

namespace ProjectCRUDTemplate.Application.ProjectCommands;

public class UpdateProjectCommand : IRequest<CommonAPIResponse>
{
    public Guid Id { get; set; }
    public required string ProjectTitle { get; set; }
    public required string Country { get; set; }
    public int Cost { get; set; }
}
