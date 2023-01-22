using BookShop.Models.Entities;
using BookShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers.API
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IProductService productService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await orderService.GetOrdersAsync();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await orderService.GetOrderByIdAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Order order)
        {
            await orderService.CreateNewOrder(order);

        }

        [HttpPut("{id}")]
        public async void Put([FromBody] Order order)
        {
            await orderService.UpdateOrder(order);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await orderService.DeleteOrder(id);
        }
    }
}
