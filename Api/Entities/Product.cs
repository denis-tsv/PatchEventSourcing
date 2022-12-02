namespace Api.Entities;

public class Product
{
    private readonly List<DomainEvent> _events = new();

    public Product(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public IReadOnlyList<DomainEvent> Events => _events;

    public void Patch(PatchProperty<string>? name, PatchProperty<string>? description)
    {
        if (name != null)
        {
            Name = name.Value!;
            _events.Add(new NameChangedDomainEvent { Name = name.Value! });
        }

        if (description != null)
        {
            Description = description.Value;
            _events.Add(new DescriptionChangedEvent { Description = description.Value });
        }
    }
}