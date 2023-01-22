using BookShop.Models.Entities.Base;

namespace BookShop.Models.Entities;

public class OrderProduct : Entity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}