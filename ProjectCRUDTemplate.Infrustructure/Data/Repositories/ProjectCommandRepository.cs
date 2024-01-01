using ProjectCRUDTemplate.Core.Entity;
using ProjectCRUDTemplate.Infrustructure.Data.DbContexts;
namespace ProjectCRUDTemplate.Infrustructure.Data.Repositories;
public class ProjectCommandRepository : CommandRepositoryBase<Project>, IProjectCommandRepository
{
    public ProjectCommandRepository(ProjectCommandDbContext dbContext) : base(dbContext)
    {
    }
}
