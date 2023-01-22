namespace BookShop.Models.ValidationModels
{
    public class OrderDetailsValidationModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
    }
}
