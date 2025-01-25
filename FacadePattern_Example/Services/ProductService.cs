using FacadePattern_Example.Entities;

namespace FacadePattern_Example.Services;

public class ProductService
{
    private readonly FakeDB _db;
    public ProductService(FakeDB db) => _db = db;

    public Product? GetProductById(int productId) =>
        _db.Products.FirstOrDefault(p => p.Id == productId);
}