using Domain.Entities;
using Domain.Enums;

namespace Business.Services;

public class ProductService
{
    private readonly Dictionary<int, Product> _products = new();

    public Product Create(string name, decimal price, SaleUnit unit,
                          Category category, int stock = 0)
    {
        var product = new Product(name, price, unit, category, stock);
        _products[product.Id] = product;
        return product;
    }

    public Product? GetById(int id)
        => _products.TryGetValue(id, out var p) ? p : null;

    public IEnumerable<Product> GetAll()
        => _products.Values.ToList();

    public IEnumerable<Product> SearchByName(string name)
        => _products.Values
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Product> GetByCategory(int categoryId)
        => _products.Values.Where(p => p.Category.Id == categoryId);

    public IEnumerable<Product> GetByTag(string tagName)
        => _products.Values
            .Where(p => p.Tags.Any(t => t.Name.Equals(tagName, StringComparison.OrdinalIgnoreCase)));

    public bool UpdatePrice(int id, decimal newPrice)
    {
        if (!_products.TryGetValue(id, out var product)) return false;
        product.UpdatePrice(newPrice);
        return true;
    }

    public bool Delete(int id) => _products.Remove(id);

    // Pagination with LINQ
    public IEnumerable<Product> GetPaged(int page, int pageSize)
        => _products.Values
            .OrderBy(p => p.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
}