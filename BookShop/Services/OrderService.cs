using BookShop.Data;
using BookShop.Models.Entities;
using BookShop.Models.ValidationModels;

namespace BookShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IEmailRepository emailRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IEmailRepository emailRepositor)
        {
            this.orderRepository = orderRepository;
            this.emailRepository = emailRepositor;
        }

        public async Task CreateNewOrder(OrderValidationModel orderValidatioModel)
        {
            var email = await emailRepository.GetByName(orderValidatioModel.Details.Email);
            email = email is null ? new Email() { EmailAddress = orderValidatioModel.Details.Email } : email;
            Order order = orderValidatioModel.ToOrderEntityModel(email);
            await orderRepository.CreateOrder(order);
        }

        public async Task CreateNewOrder(Order order)
        {
            await orderRepository.CreateOrder(order);
        }

        public async Task DeleteOrder(int id)
        {
            await orderRepository.DeleteOrder(id);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await orderRepository.GetById(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await orderRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByEmail(string email)
        {
            return await orderRepository.GetByEmail(email);
        }

        public async Task UpdateOrder(Order order)
        {
            await orderRepository.UpdateAsync(order);
        }
    }
}
