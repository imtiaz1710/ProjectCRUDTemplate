using Dapper;
using ProjectCRUDTemplate.Infrustructure.Data.DbContexts;

namespace ProjectCRUDTemplate.Infrustructure.Data.Repositories;

public class ProjectQueryRepository(ProjectQueryDbContext context) : IProjectQueryRepository
{
    private readonly ProjectQueryDbContext _context = context;

    public async Task<List<Project>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var query = "SELECT * FROM Projects";

        using (var connection = _context.CreateConnection())
        {
            var projects = await connection.QueryAsync<Project>(query);
            return projects.ToList();
        }
    }

    public async Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = $"SELECT * FROM Projects WHERE id = '{id}'";

        using (var connection = _context.CreateConnection())
        {
            var project = await connection.QueryFirstOrDefaultAsync<Project>(query);
            return project;
        }
    }
}
