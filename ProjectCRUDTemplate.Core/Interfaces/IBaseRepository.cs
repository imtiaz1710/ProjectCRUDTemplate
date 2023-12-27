using ProjectCRUDTemplate.Core.Interfaces;

namespace ProjectCRUDTemplate.Infrustructure.Data;

public interface IBaseRepository<T>: IQueryRepositoryBase<T>,ICommandRepositoryBase<T> where T : class { }
