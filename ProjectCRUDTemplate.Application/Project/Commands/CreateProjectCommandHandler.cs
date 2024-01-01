﻿namespace ProjectCRUDTemplate.Application.ProjectCommands;

public class CreateProjectCommandHandler(IProjectCommandRepository projectRepository) : 
    IRequestHandler<CreateProjectCommand, CommonAPIResponse>
{
    private readonly IProjectCommandRepository _projectRepository = projectRepository;

    public async Task<CommonAPIResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectEntity = new Project
        {
            Cost = request.Cost,
            Country = request.Country,
            ProjectTitle = request.ProjectTitle
        };

        var response = await _projectRepository.AddAsync(projectEntity);

        return new CommonAPIResponse(data: response, message: ApplicationConstants.DataCreatedSuccessfull);
    }
}
