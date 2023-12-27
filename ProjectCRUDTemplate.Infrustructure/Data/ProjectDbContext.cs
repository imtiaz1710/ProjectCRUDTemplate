using Microsoft.EntityFrameworkCore;
using ProjectCRUDTemplate.Core.Entity;

namespace ProjectCRUDTemplate.Infrustructure.Data;

public class ProjectDbContext: DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {

    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    //optionsBuilder.UseSqlServer("Server=DESKTOP-4H6AU0O\\SQLEXPRESS;Database=ProjectCRUDTemplateDB;User Id=izm;Password=123456;");
    //    base.OnConfiguring(optionsBuilder);
    //}
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
    public DbSet<Project> Projects {  get; set; }
    public DbSet<Employee> Employees { get; set; }
}
