namespace Domain.Entities;

public class Store
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public TimeSpan OpeningTime { get; private set; }
    public TimeSpan ClosingTime { get; private set; }

    private readonly List<Employee> _employees = new();
    public IReadOnlyList<Employee> Employees => _employees.AsReadOnly();

    private static int _nextId = 1;

    public Store(string name, string address, TimeSpan openingTime, TimeSpan closingTime)
    {
        Id = _nextId++;
        Name = name;
        Address = address;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
    }

    public void AddEmployee(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);
        _employees.Add(employee);
    }

    public void RemoveEmployee(int employeeId)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == employeeId);
        if (employee is not null) _employees.Remove(employee);
    }

    public override string ToString() =>
        $"[{Id}] {Name} — {Address} ({OpeningTime:hh\\:mm}–{ClosingTime:hh\\:mm})";
}