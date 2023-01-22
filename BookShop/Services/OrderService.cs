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
    }
}
