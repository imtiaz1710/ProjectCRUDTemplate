using MediatR;
using ProjectCRUDTemplate.Application.Common;
using ProjectCRUDTemplate.Core.Entity;
using ProjectCRUDTemplate.Infrustructure.Data;

namespace ProjectCRUDTemplate.Application.ProjectCommands;

public class UpdateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<UpdateProjectCommand, CommonAPIResponse>
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<CommonAPIResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entity = await _projectRepository.GetByIdAsync(request.Id);
        if (entity == null) throw new Exception("Project not found");

        entity.ProjectTitle = request.ProjectTitle;
        entity.Country = request.Country;
        entity.Cost = request.Cost;

        await _projectRepository.UpdateAsync(entity, cancellationToken);
        return new CommonAPIResponse("Project Updated SuccessFully!", request);
    }
}
