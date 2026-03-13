namespace Domain.Entities;

public class Company
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string TaxId { get; private set; }

    private readonly List<Store> _stores = new();
    public IReadOnlyList<Store> Stores => _stores.AsReadOnly();

    private static int _nextId = 1;

    public Company(string name, string taxId)
    {
        Id = _nextId++;
        Name = name;
        TaxId = taxId;
    }

    public void AddStore(Store store)
    {
        ArgumentNullException.ThrowIfNull(store);
        _stores.Add(store);
    }

    public override string ToString() => $"[{Id}] {Name} — TaxId: {TaxId}";
}