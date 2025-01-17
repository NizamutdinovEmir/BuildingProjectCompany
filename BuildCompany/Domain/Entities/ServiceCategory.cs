namespace BuildCompany.Domain.Entities;

public class ServiceCategory : EntityBase
{
    public ICollection<Service>? Services { get; }
}