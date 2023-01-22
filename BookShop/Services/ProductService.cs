using BookShop.Data;
using BookShop.Models.Entities;
using BookShop.Models.ValidationModels;

namespace BookShop.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IGenresRepository _genresRepository;

    public ProductService(
        IProductRepository productRepository, 
        IGenresRepository genresRepository)
    {
        _productRepository = productRepository;
        _genresRepository = genresRepository;
    }

    public async Task CreateNewProduct(ProductValidationModel model)
    {
        var genre = await _genresRepository.GetGenreById(model.GenreId);
        var product = Product.Create(model, genre);
        await _productRepository.InsertProductAsync(product);
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _productRepository.GetById(id);
        await _productRepository.Delete(product);
    }

    public async Task<List<Genre>> GetGenres()
    {
        return (await _genresRepository.GetAllGenres()).ToList();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _productRepository.GetAll();
    }

    public async Task UpdateProduct(ProductValidationModel model)
    {
        var genre = await _genresRepository.GetGenreById(model.GenreId);
        var product = Product.Create(model, genre);

        await _productRepository.Update(product);
    }
}