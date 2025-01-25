using FacadePattern_Example.Entities;

namespace FacadePattern_Example;

public class FakeDB
{
    public List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1000 },
        new Product { Id = 2, Name = "Phone", Price = 500 }
    };

    public List<Customer> Customers = new() {
        new Customer { Id = 1, Name = "Ali" },
        new Customer { Id = 2, Name = "Reza" }
    };

    public List<Order> Orders = new();
}
