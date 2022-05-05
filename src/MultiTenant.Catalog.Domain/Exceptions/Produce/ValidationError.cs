namespace MultiTenant.Catalog.Domain.Exceptions.Produce;

public class ValidationError
{
    public string PropertyName { get; set; }
    public List<ErrorProperty> Validations { get; set; } = new();
}