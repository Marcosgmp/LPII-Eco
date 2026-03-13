using Domain.Entities;

namespace Business.Services;

public class CustomerService
{
    private readonly List<Customer> _customers = new();

    public Customer Register(string name, string email, string password)
    {
        if (_customers.Any(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("E-mail already registered.");

        var customer = new Customer(name, email, password);
        _customers.Add(customer);
        return customer;
    }

    public Customer? Login(string email, string password)
        => _customers.FirstOrDefault(c => c.Authenticate(email, password));

    public Customer? GetById(int id)
        => _customers.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Customer> GetAll() => _customers.AsReadOnly();

    public bool Delete(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer is null) return false;
        _customers.Remove(customer);
        return true;
    }
}