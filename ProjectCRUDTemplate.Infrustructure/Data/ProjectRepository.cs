using ProjectCRUDTemplate.Core.Entity;
namespace ProjectCRUDTemplate.Infrustructure.Data;
public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(ProjectDbContext dbContext) : base(dbContext)
    {
    }
}
