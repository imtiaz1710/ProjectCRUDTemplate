namespace ProjectCRUDTemplate.Core.Entity;

public class Project : BaseAuditableEntity
{
    public required string ProjectTitle { get; set; }
    public required string Country { get; set; }
    public int Cost { get; set; }
    public IList<Employee> Employees { get; private set; } = new List<Employee>();
}
