using BookShop.Models.Entities;
using BookShop.Models.ValidationModels;

namespace BookShop.Services;

public interface IProductService
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task CreateNewProduct(ProductValidationModel model);
    Task CreateNewProduct(Product model);
    Task UpdateProduct(ProductValidationModel model);
    Task<List<Genre>> GetGenres();
    Task DeleteProduct(int id);
    Task UpdateProduct(Product product);
}