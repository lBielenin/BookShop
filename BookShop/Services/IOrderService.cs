using BookShop.Models.Entities;
using BookShop.Models.ValidationModels;

namespace BookShop.Services
{
    public interface IOrderService
    {
        Task CreateNewOrder(OrderValidationModel orderValidatioModel);
        Task CreateNewOrder(Order order);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
        Task<IEnumerable<Order>> GetOrdersByEmail(string email);
    }
}
