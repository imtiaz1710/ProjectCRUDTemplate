using ProjectCRUDTemplate.Core.Interfaces;

namespace ProjectCRUDTemplate.Application.ProjectCommands;

public class DeleteProjectCommandHandler(IProjectCommandRepository projectCommandRepository, IProjectQueryRepository projectQueryRepository) : IRequestHandler<DeleteProjectCommand, CommonAPIResponse>
{
    private readonly IProjectCommandRepository _projectRepository = projectCommandRepository;
    private readonly IProjectQueryRepository _projectQueryRepository = projectQueryRepository;

    public async Task<CommonAPIResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await _projectQueryRepository.GetByIdAsync(request.Id);

        if(entity == null) throw new Exception(ApplicationConstants.ItemNotFound);

        await _projectRepository.DeleteAsync(entity);

        return new CommonAPIResponse(ApplicationConstants.DataDeletedSuccessfull, entity);
    }
}
