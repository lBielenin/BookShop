using BookShop.Models.BasketModels;
using BookShop.Models.Entities.Base;
using BookShop.Models.ValidationModels;

namespace BookShop.Models.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public ProductDetail ProductDetail { get; set; }

    internal static Product Create(ProductValidationModel model, Genre genre)
    {
        return new Product()
        {
            Name = model.Name,
            Price = model.Price,
            ProductDetail = new ProductDetail()
            {
                Author = model.Author,
                Description = model.Description,
                Genre = genre
            }
        };
    }

    internal ProductValidationModel ToProductValidationModel()
    {
        return new()
        {
            Author = ProductDetail.Author,
            Description = ProductDetail.Description,
            GenreId = ProductDetail.Genre.Id,
            Name = Name,
            Price = Price
        };
    }

    internal BasketModel ToBasketModel()
    {
        return new()
        {
            Id = Id,
            Author = ProductDetail.Author,
            Description = ProductDetail.Description,
            GenreId = ProductDetail.Genre.Id,
            Name = Name,
            Price = Price,
            Quantity = 1
        };
    }
}