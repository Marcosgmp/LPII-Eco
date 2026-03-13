using Domain.Entities;
using Domain.Enums;

namespace Business.Services;

public class EmployeeService
{
    private readonly List<Employee> _employees = new();

    public Cashier CreateCashier(string name, decimal salary, TimeSpan shiftStart,
                                 TimeSpan shiftEnd, ContractType contractType)
    {
        var cashier = new Cashier(name, salary, shiftStart, shiftEnd, contractType);
        _employees.Add(cashier);
        return cashier;
    }

    public Stocker CreateStocker(string name, decimal salary, TimeSpan shiftStart,
                                 TimeSpan shiftEnd, ContractType contractType)
    {
        var stocker = new Stocker(name, salary, shiftStart, shiftEnd, contractType);
        _employees.Add(stocker);
        return stocker;
    }

    public Manager CreateManager(string name, decimal salary, TimeSpan shiftStart,
                                 TimeSpan shiftEnd, ContractType contractType)
    {
        var manager = new Manager(name, salary, shiftStart, shiftEnd, contractType);
        _employees.Add(manager);
        return manager;
    }

    public Employee? GetById(int id)
        => _employees.FirstOrDefault(e => e.Id == id);

    public IEnumerable<Employee> GetAll() => _employees.AsReadOnly();

    public IEnumerable<Employee> GetByRole(EmployeeRole role)
        => _employees.Where(e => e.Role == role);

    public bool Delete(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee is null) return false;
        _employees.Remove(employee);
        return true;
    }
}