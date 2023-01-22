using BookShop.Models.Entities.Base;

namespace BookShop.Models.Entities;

public class ProductDetail : Entity
{
    public string Description { get; set; }
    public string Author { get; set; }
    public Genre Genre { get; set; }
}