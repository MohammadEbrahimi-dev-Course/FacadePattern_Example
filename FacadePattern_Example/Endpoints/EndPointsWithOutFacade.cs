using Microsoft.AspNetCore.Mvc;
using FacadePattern_Example.DTO;
using FacadePattern_Example.Entities;
using FacadePattern_Example.Services;

namespace FacadePattern_Example.Endpoints;

public static class EndPointsWithOutFacade
{
    public static WebApplication MapWithoutFacadeEndPoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/withoutfacade")
            .WithDescription("Lookup and Find facade");

        _ = root.MapPost("/", PlaceOrder)
            .Produces<string>()
            .WithSummary("Place Order Without Facade")
            .WithDescription("\n    Post /withoutfacade");

        _ = root.MapGet("/", GetOrders)
            .Produces<List<OrderItem>>()
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("List of Orders Without Facade")
            .WithDescription("\n    GET /withoutfacade");

        return app;
    }

    public static async Task<IResult> PlaceOrder([FromQuery] int customerId, [FromQuery] int productId, [FromQuery] int quantity
        , [FromServices] ProductService productService, [FromServices] CustomerService customerService, [FromServices] OrderService orderService)
    {
        try
        {
            var customer = customerService.GetCustomerById(customerId);
            if (customer == null) return Results.NotFound("Customer not found");

            var product = productService.GetProductById(productId);
            if (product == null) return Results.NotFound("Product not found");

            orderService.CreateOrder(new Order { Id = 1, CustomerId = customerId, ProductId = productId, Quantity = quantity });

            return Results.Ok("Order placed successfully!");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public static async Task<IResult> GetOrders([FromServices] ProductService productService, [FromServices] CustomerService customerService, [FromServices] OrderService orderService)
    {
        try
        {
            List<OrderItem> OrderList = new List<OrderItem>();

            var orders = orderService.GetOrders();

            foreach (var order in orders)
            {
                var customer = customerService.GetCustomerById(order.CustomerId);
                var product = productService.GetProductById(order.ProductId);

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
            return Results.Ok(OrderList);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
