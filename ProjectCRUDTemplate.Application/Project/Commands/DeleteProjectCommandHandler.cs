using MediatR;
using ProjectCRUDTemplate.Application.Common;
using ProjectCRUDTemplate.Infrustructure.Data;

namespace ProjectCRUDTemplate.Application.ProjectCommands;
public class DeleteProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<DeleteProjectCommand, CommonAPIResponse>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    public async Task<CommonAPIResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entity = await _projectRepository.GetByIdAsync(request.Id);
        if(entity == null) throw new Exception("Project not found");

        await _projectRepository.DeleteAsync(entity);
        return new CommonAPIResponse("Successfully deleted!", entity);
    }
}
