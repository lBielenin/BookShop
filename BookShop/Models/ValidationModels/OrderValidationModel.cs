using BookShop.Models.BasketModels;
using BookShop.Models.Entities;

namespace BookShop.Models.ValidationModels
{
    public class OrderValidationModel
    {
        public List<BasketModel> BasketItems { get; set; }
        public OrderDetailsValidationModel Details { get; set; }

        internal Order ToOrderEntityModel(Email email)
        {
            return new()
            {
                Address = new Address()
                {
                    City = Details.City,
                    PostalCode = Details.PostalCode,
                    StreetName = Details.StreetName,
                    StreetNumber = Details.StreetNumber
                },
                TotalPrice = BasketItems.Select(b => b.Quantity * b.Price).Sum(),
                Email = email,
                OrderProducts = BasketItems.Select(bi => new OrderProduct() { ProductId = bi.Id, Quantity = bi.Quantity }).ToList()
            };
        }
    }
}
