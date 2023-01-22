using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.ValidationModels
{
    public class OrderDetailsValidationModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name field should have length between 1 and 100!")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "] field should have length between 1 and 100!")]
        public string Surname { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "StreetName field should have length between 1 and 100!")]
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City field should have length between 1 and 100!")]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"\d\d-\d\d\d", ErrorMessage = "Postal code should be in format 'dd-ddd' like '02-222'!")]
        public string PostalCode { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
