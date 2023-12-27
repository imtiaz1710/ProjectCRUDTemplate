namespace ProjectCRUDTemplate.Core.Interfaces;

public interface IQueryRepositoryBase<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

    //Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);
    //Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    //Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    //Task<int> CountAsync(CancellationToken cancellationToken = default);
    //Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    //Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    //IAsyncEnumerable<T> AsAsyncEnumerable(ISpecification<T> specification);
}
