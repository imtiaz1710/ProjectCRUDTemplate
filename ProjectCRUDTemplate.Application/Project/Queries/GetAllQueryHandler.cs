namespace ProjectCRUDTemplate.Application.ProjectQueries;

public class GetAllQueryHandler(IProjectRepository projectRepository) : IRequestHandler<GetAllProjectQuery, CommonAPIResponse>
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<CommonAPIResponse> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
    {
        var data =  await _projectRepository.GetAllAsync();

        return new CommonAPIResponse(ApplicationConstants.DataRetriveSuccessfull, data);
    }
}
