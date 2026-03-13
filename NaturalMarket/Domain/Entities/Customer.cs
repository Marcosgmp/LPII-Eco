namespace Domain.Entities;

public class Customer
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    private string _passwordHash;
    private readonly List<Sale> _purchaseHistory = new();
    public IReadOnlyList<Sale> PurchaseHistory => _purchaseHistory.AsReadOnly();

    private static int _nextId = 1;

    public Customer(string name, string email, string password)
    {
        Id = _nextId++;
        Name = name;
        Email = email;
        _passwordHash = Hash(password);
    }

    public bool Authenticate(string email, string password)
        => Email == email && _passwordHash == Hash(password);

    public void AddPurchase(Sale sale) => _purchaseHistory.Add(sale);

    private static string Hash(string password)
        => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));

    public override string ToString() => $"[{Id}] {Name} — {Email}";
}