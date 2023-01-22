using BookShop.Models.ValidationModels;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IBasketService basketService;

        public OrderController(IOrderService orderService, IBasketService basketService)
        {
            this.orderService = orderService;
            this.basketService = basketService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var validationModel = new OrderValidationModel
            {
                BasketItems = basketService.GetAllBasket()
            };

            return View(validationModel);
        }

        [Route("Create")]
        public async Task<IActionResult> Create(OrderValidationModel orderValidatioModel)
        {
            orderValidatioModel.BasketItems = basketService.GetAllBasket();
            await orderService.CreateNewOrder(orderValidatioModel);
            basketService.ClearBasket();
            return RedirectToAction("Message", "SharedConfirmation",
            new
            {
                message = "You succesfully created new product!",
                confirmUrl = Url.Action("Index", "Home")
            });
        }
    }
}
