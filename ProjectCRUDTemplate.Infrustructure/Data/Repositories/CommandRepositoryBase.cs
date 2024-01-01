using ProjectCRUDTemplate.Infrustructure.Data.DbContexts;

namespace ProjectCRUDTemplate.Infrustructure.Data.Repositories;

public class CommandRepositoryBase<T>(ProjectCommandDbContext dbContext) : ICommandRepository<T> where T : BaseEntity
{
    private readonly ProjectCommandDbContext _dbContext = dbContext;
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    //public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    //{
    //    ArgumentNullException.ThrowIfNull(id);
    //    return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    //}

    //public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    //{
    //    return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    //}

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
