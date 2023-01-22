using BookShop.Models.Entities;

namespace BookShop.Models.ValidationModels
{
    public class ProductValidationModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
    }
}

