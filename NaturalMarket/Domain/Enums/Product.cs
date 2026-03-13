using Domain.Enums;

namespace Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public SaleUnit SaleUnit { get; private set; }
    public int StockQuantity { get; private set; }
    public Category Category { get; private set; }

    private readonly List<Tag> _tags = new();
    public IReadOnlyList<Tag> Tags => _tags.AsReadOnly();

    private static int _nextId = 1;

    public Product(string name, decimal price, SaleUnit saleUnit,
                   Category category, int stockQuantity = 0)
    {
        Id = _nextId++;
        Name = name;
        Price = price;
        SaleUnit = saleUnit;
        Category = category;
        StockQuantity = stockQuantity;
    }

    public void AddTag(Tag tag)
    {
        if (!_tags.Any(t => t.Id == tag.Id))
            _tags.Add(tag);
    }

    public void RemoveTag(int tagId)
    {
        var tag = _tags.FirstOrDefault(t => t.Id == tagId);
        if (tag is not null) _tags.Remove(tag);
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice < 0) throw new ArgumentException("Price cannot be negative.");
        Price = newPrice;
    }

    public void UpdateStock(int delta)
    {
        if (StockQuantity + delta < 0)
            throw new InvalidOperationException("Insufficient stock.");
        StockQuantity += delta;
    }

    public override string ToString() =>
        $"[{Id}] {Name} — R${Price:F2}/{SaleUnit} | Stock: {StockQuantity}";
}