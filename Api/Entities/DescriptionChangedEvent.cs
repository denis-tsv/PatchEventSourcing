namespace Api.Entities;

public class DescriptionChangedEvent : DomainEvent
{
    public string? Description { get; set; }
}