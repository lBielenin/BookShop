using BookShop.Models.Entities.Base;

namespace BookShop.Models.Entities;

public class Order : Entity
{
    public double TotalPrice { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
    public int? UserId { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}