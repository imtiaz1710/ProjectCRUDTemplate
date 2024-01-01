using ProjectCRUDTemplate.Core.Interfaces;

namespace ProjectCRUDTemplate.Application.ProjectQueries;

public class GetAllProjectQueryHandler(IProjectQueryRepository projectQueryRepository) : IRequestHandler<GetAllProjectQuery, CommonAPIResponse>
{
    private readonly IProjectQueryRepository _projectQueryRepository = projectQueryRepository;

    public async Task<CommonAPIResponse> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
    {
        var data =  await _projectQueryRepository.GetAllAsync();

        return new CommonAPIResponse(ApplicationConstants.DataRetriveSuccessfull, data);
    }
}
