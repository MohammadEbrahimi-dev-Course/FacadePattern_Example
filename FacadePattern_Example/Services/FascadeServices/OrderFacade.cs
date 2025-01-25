using FacadePattern_Example.DTO;
using FacadePattern_Example.Entities;

namespace FacadePattern_Example.Services.FascadeServices;

public class OrderFacade
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;
    private readonly OrderService _orderService;

    public OrderFacade(ProductService productService, CustomerService customerService, OrderService orderService)
    {
        _productService = productService;
        _customerService = customerService;
        _orderService = orderService;
    }

    public string PlaceOrder(int customerId, int productId, int quantity)
    {
        var customer = _customerService.GetCustomerById(customerId);
        if (customer == null) return "Customer not found";

        var product = _productService.GetProductById(productId);
        if (product == null) return "Product not found";

        _orderService.CreateOrder(new Order { Id = 1, CustomerId = customerId, ProductId = productId, Quantity = quantity });

        return "Order placed successfully!";
    }

    public List<OrderItem> GetOrders()
    {

        List<OrderItem> OrderList = new List<OrderItem>();

        var orders = _orderService.GetOrders();

        foreach (var order in orders)
        {
            var customer = _customerService.GetCustomerById(order.CustomerId);
            var product = _productService.GetProductById(order.ProductId);

            OrderList.Add(new OrderItem
            {
                Id = order.Id,
                ProductId = order.ProductId,
                CustomerId = order.CustomerId,
                Quantity = order.Quantity,  
                Customer = customer,
                Product = product
            });
        }

        return OrderList;
    }
}
