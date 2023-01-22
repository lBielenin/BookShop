using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateOrder(Order order)
        {
            await context.Orders.AddAsync(order);

            await context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await context.Orders.FindAsync(id);
            context.Orders.Remove(order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders
                .Include(o => o.OrderProducts)
                .Include(o => o.Email)
                .Include(o => o.Address)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByEmail(string email)
        {
            return await context.Orders
                .Include(o => o.OrderProducts)
                .Include(o => o.Email)
                .Include(o => o.Address)
                .Where(o => o.Email.EmailAddress == email)
                .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await context.Orders.FirstAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order order)
        {
            context.Orders.Update(order);
        }

    }
}
