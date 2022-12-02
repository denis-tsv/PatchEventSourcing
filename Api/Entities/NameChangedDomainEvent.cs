namespace Api.Entities;

public class NameChangedDomainEvent : DomainEvent
{
    public string Name { get; set; } = null!;
}