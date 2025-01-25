using FacadePattern_Example.Entities;

namespace FacadePattern_Example.Services;

public class CustomerService
{
    private readonly FakeDB _db;
    public CustomerService(FakeDB db) => _db = db;

    public Customer? GetCustomerById(int customerId) =>
        _db.Customers.FirstOrDefault(c => c.Id == customerId);
}
