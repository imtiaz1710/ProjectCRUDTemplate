namespace ProjectCRUDTemplate.Core.Entity;

public class Employee: BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string CountryName { get; set; }
    public required Gender Gender { get; set; }
    public required string PhoneNo { get; set; }
    public string? Email { get; set; }
    public Project? Project { get; set; }
}
