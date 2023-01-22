using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InsertProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);

        _dbContext.SaveChanges();
    }
    public async Task<List<Product>> GetAll()
    {
        return await _dbContext.Products.Include(p => p.ProductDetail.Genre).ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _dbContext.Products.Include(p => p.ProductDetail.Genre).FirstAsync(prod => prod.Id == id);

    }

    public async Task Update(Product product)
    {
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}