using Microsoft.AspNetCore.Mvc;
using FacadePattern_Example.DTO;
using FacadePattern_Example.Services.FascadeServices;

namespace FacadePattern_Example.Endpoints;

public static class EndPointsWithFacade
{
    public static WebApplication MapFacadeEndPoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/facade")
            .WithDescription("add and list of  orders");

        _ = root.MapPost("/", FacadePlaceOrder)
            .Produces<string>()
            .WithSummary("Place Order With Facade")
            .WithDescription("\n    Post /facade");

        _ = root.MapGet("/", FacadeGetOrders)
            .Produces<List<OrderItem>>()
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("List of Orders With Facade")
            .WithDescription("\n    GET /facade");

        return app;
    }

    public static async Task<IResult> FacadePlaceOrder([FromQuery] int customerId, [FromQuery] int productId, [FromQuery] int quantity, [FromServices] OrderFacade orderFacade)
    {
        try
        {
            var result = orderFacade.PlaceOrder(customerId, productId, quantity);
            if (result == "Customer not found" || result == "Product not found") return Results.NotFound(result);

            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public static async Task<IResult> FacadeGetOrders([FromServices] OrderFacade orderFacade)
    {
        try
        {
            return Results.Ok(orderFacade.GetOrders());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
