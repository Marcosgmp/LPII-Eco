namespace Domain.Entities;

public class ShoppingCart
{
    private readonly List<SaleItem> _items = new();
    public IReadOnlyList<SaleItem> Items => _items.AsReadOnly();
    public decimal Total => _items.Sum(i => i.Subtotal);

    public void AddItem(Product product, decimal quantity)
        => _items.Add(new SaleItem(product, quantity));

    public void RemoveItem(int productId)
    {
        var item = _items.FirstOrDefault(i => i.Product.Id == productId);
        if (item is not null) _items.Remove(item);
    }

    public void Clear() => _items.Clear();

    public List<SaleItem> GetItems() => new List<SaleItem>(_items);

    public void PrintSummary()
    {
        Console.WriteLine("--- Shopping Cart ---");
        foreach (var item in _items)
            Console.WriteLine($"  {item}");
        Console.WriteLine($"  TOTAL: R${Total:F2}");
    }
}