namespace ProjectCRUDTemplate.Application.ProjectCommands;
public class DeleteProjectCommand : IRequest<CommonAPIResponse>
{
    public Guid Id { get; set; }
}
