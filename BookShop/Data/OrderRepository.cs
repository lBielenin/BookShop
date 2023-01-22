using BookShop.Models.Entities;

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
    }
}
