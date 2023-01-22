using BookShop.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.ValidationModels
{
    public class ProductValidationModel
    {
        public int Id { get; set; }
        public int ProductDetailId { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name field should have length between 1 and 100!")]
        public string Name { get; set; }
        [Range(1, 500, ErrorMessage = "Price should be between 1 and 500!")]
        public double Price { get; set; }
        [StringLength(1000, MinimumLength = 16, ErrorMessage = "Description field should have between 16 and 1000 characters")]
        public string Description { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Author field should have between 1 and 1000 characters")]
        public string Author { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please, pick a genre!")]
        public int GenreId { get; set; }
    }
}

