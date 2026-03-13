namespace Domain.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    private static int _nextId = 1;

    public Category(string name, string description = "")
    {
        Id = _nextId++;
        Name = name;
        Description = description;
    }

    public override string ToString() => $"[{Id}] {Name}";
}

public class Tag
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private static int _nextId = 1;

    public Tag(string name)
    {
        Id = _nextId++;
        Name = name;
    }

    public override string ToString() => $"#{Name}";
}