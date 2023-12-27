using MediatR;
using ProjectCRUDTemplate.API.Models.ProjectCommands;
using ProjectCRUDTemplate.Application.Common;
using ProjectCRUDTemplate.Core.Entity;
using ProjectCRUDTemplate.Infrustructure.Data;

namespace ProjectCRUDTemplate.Application.ProjectCommands;

public class CreateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<CreateProjectCommand, CommonAPIResponse>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    public async Task<CommonAPIResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectEntity = new Project
        {
            Cost = request.Cost,
            Country = request.Country,
            ProjectTitle = request.ProjectTitle
        };

        var response = await _projectRepository.AddAsync(projectEntity);

        return new CommonAPIResponse(data: response, message: "Successfully Created Project!");
    }
}
