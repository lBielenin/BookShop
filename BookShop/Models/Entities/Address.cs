using BookShop.Models.Entities.Base;

namespace BookShop.Models.Entities;

public class Address : Entity
{
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}