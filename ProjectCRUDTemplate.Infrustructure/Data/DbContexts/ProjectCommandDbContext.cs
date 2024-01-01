namespace ProjectCRUDTemplate.Infrustructure.Data.DbContexts;

public class ProjectCommandDbContext : DbContext
{
    public ProjectCommandDbContext(DbContextOptions<ProjectCommandDbContext> options) : base(options)
    {

    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        foreach (var item in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            switch (item.State)
            {
                case EntityState.Added:
                    item.Entity.Created = DateTime.Now;
                    //Todo
                    //
                    //item.Entity.CreatedBy = _currentUserService.UserId;
                    break;
                case EntityState.Modified:
                    item.Entity.LastModified = DateTime.Now;
                    //Todo
                    //
                    //item.Entity.LastUpdatedDate = _currentUserService.UserId;
                    break;
                default:
                    break;
            }
        }

        return base.SaveChangesAsync();
    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
