using BookShop.Models.Entities;

namespace BookShop.Data
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        Task DeleteOrder(int id);
        Task<Order> GetById(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task<IEnumerable<Order>> GetByEmail(string email);
    }
}
