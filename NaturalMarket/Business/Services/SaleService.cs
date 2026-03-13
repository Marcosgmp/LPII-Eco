using Domain.Entities;
using Domain.Enums;

namespace Business.Services;

public class SaleService
{
    private readonly List<Sale> _sales = new();

    public Sale ProcessSale(Cashier cashier, Customer? customer,
                            ShoppingCart cart, PaymentMethod paymentMethod)
    {
        if (!cart.Items.Any())
            throw new InvalidOperationException("Cart is empty.");

        var items = cart.GetItems();

        foreach (var item in items)
            item.Product.UpdateStock(-(int)item.Quantity);

        var sale = cashier.ProcessSale(customer, items, paymentMethod);
        _sales.Add(sale);
        cart.Clear();
        return sale;
    }

    public IEnumerable<Sale> GetAll() => _sales.AsReadOnly();

    public IEnumerable<Sale> GetByCustomer(int customerId)
        => _sales.Where(s => s.Customer?.Id == customerId);

    public decimal TotalRevenue() => _sales.Sum(s => s.Total);
}