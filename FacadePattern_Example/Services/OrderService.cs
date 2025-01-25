using FacadePattern_Example.Entities;

namespace FacadePattern_Example.Services;

public class OrderService
{
    private readonly FakeDB _db;
    public OrderService(FakeDB db) => _db = db;

    public void CreateOrder(Order order) => _db.Orders.Add(order);
    
    public List<Order> GetOrders() => _db.Orders.ToList();
}
