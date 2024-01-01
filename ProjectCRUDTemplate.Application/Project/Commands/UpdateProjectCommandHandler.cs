using ProjectCRUDTemplate.Core.Interfaces;

namespace ProjectCRUDTemplate.Application.ProjectCommands;

public class UpdateProjectCommandHandler(IProjectCommandRepository projectCommandRepository, IProjectQueryRepository projectQueryRepository) : IRequestHandler<UpdateProjectCommand, CommonAPIResponse>
{
    private readonly IProjectCommandRepository _projectRepository = projectCommandRepository;
    private readonly IProjectQueryRepository _projectQueryRepository = projectQueryRepository;

    public async Task<CommonAPIResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await _projectQueryRepository.GetByIdAsync(request.Id);

        if (entity == null) throw new Exception(ApplicationConstants.ItemNotFound);

        entity.ProjectTitle = request.ProjectTitle;
        entity.Country = request.Country;
        entity.Cost = request.Cost;

        await _projectRepository.UpdateAsync(entity, cancellationToken);

        return new CommonAPIResponse(ApplicationConstants.DataUpdatedSuccessfull, request);
    }
}
