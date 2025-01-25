using FacadePattern_Example.Entities;

namespace FacadePattern_Example.DTO;

public class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
}
