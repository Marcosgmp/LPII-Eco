using Domain.Enums;

namespace Domain.Entities;

public abstract class Employee
{
    public int Id { get; private set; }
    public string Name { get; protected set; }
    public decimal Salary { get; protected set; }
    public TimeSpan ShiftStart { get; protected set; }
    public TimeSpan ShiftEnd { get; protected set; }
    public ContractType ContractType { get; protected set; }
    public abstract EmployeeRole Role { get; }

    private static int _nextId = 1;

    protected Employee(string name, decimal salary, TimeSpan shiftStart,
                       TimeSpan shiftEnd, ContractType contractType)
    {
        Id = _nextId++;
        Name = name;
        Salary = salary;
        ShiftStart = shiftStart;
        ShiftEnd = shiftEnd;
        ContractType = contractType;
    }

    public override string ToString() => $"[{Id}] {Name} — {Role} ({ContractType})";
}

public sealed class Cashier : Employee
{
    public override EmployeeRole Role => EmployeeRole.Cashier;

    public Cashier(string name, decimal salary, TimeSpan shiftStart,
                   TimeSpan shiftEnd, ContractType contractType)
        : base(name, salary, shiftStart, shiftEnd, contractType) { }

    public Sale ProcessSale(Customer? customer, List<SaleItem> items, PaymentMethod payment)
        => new Sale(this, customer, items, payment);
}

public sealed class Stocker : Employee
{
    public override EmployeeRole Role => EmployeeRole.Stocker;

    public Stocker(string name, decimal salary, TimeSpan shiftStart,
                   TimeSpan shiftEnd, ContractType contractType)
        : base(name, salary, shiftStart, shiftEnd, contractType) { }
}

public sealed class Manager : Employee
{
    public override EmployeeRole Role => EmployeeRole.Manager;

    public Manager(string name, decimal salary, TimeSpan shiftStart,
                   TimeSpan shiftEnd, ContractType contractType)
        : base(name, salary, shiftStart, shiftEnd, contractType) { }

    public Customer RegisterCustomer(string name, string email, string password)
        => new Customer(name, email, password);
}