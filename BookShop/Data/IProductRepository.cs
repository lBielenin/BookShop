using BookShop.Models.Entities;

namespace BookShop.Data;

public interface IProductRepository
{
    Task InsertProductAsync(Product product);
    Task<List<Product>> GetAll();
    Task<Product> GetById(int id);
    Task Update(Product product);
    Task Delete(Product product);
}