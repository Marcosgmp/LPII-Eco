using Domain.Enums;

namespace Domain.Entities;

public class SaleItem
{
    public Product Product { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Subtotal => UnitPrice * Quantity;

    public SaleItem(Product product, decimal quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive.");
        Product = product;
        Quantity = quantity;
        UnitPrice = product.Price;
    }

    public override string ToString() =>
        $"{Product.Name} x{Quantity} = R${Subtotal:F2}";
}

public class Sale
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Employee Cashier { get; private set; }
    public Customer? Customer { get; private set; }
    public IReadOnlyList<SaleItem> Items { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public decimal Total => Items.Sum(i => i.Subtotal);

    private static int _nextId = 1;

    public Sale(Employee cashier, Customer? customer,
                List<SaleItem> items, PaymentMethod paymentMethod)
    {
        if (!items.Any()) throw new InvalidOperationException("Sale must have at least one item.");
        Id = _nextId++;
        CreatedAt = DateTime.Now;
        Cashier = cashier;
        Customer = customer;
        Items = items.AsReadOnly();
        PaymentMethod = paymentMethod;

        customer?.AddPurchase(this);
    }

    public override string ToString()
    {
        var customerName = Customer?.Name ?? "Anonymous";
        return $"Sale #{Id} | {CreatedAt:dd/MM/yyyy HH:mm} | Customer: {customerName} | Total: R${Total:F2} | {PaymentMethod}";
    }
}