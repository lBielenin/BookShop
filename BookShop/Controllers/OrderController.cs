using BookShop.Models.ValidationModels;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public IActionResult Index(IEnumerable<string> messages = null)
        {
            OrderDetailsValidationModel model = null;
            if (messages is not null && messages.Count() > 0)
            {
                ViewBag.ErrorMessages = messages;
                var stringCreateOrder = HttpContext.Session.GetString("CreateOrder");
                if(stringCreateOrder is not null)
                    model = JsonSerializer.Deserialize<OrderDetailsValidationModel>(stringCreateOrder);

            }

            var validationModel = new OrderValidationModel
            {
                BasketItems = basketService.GetAllBasket(),
                Details = model
            };

            return View(validationModel);
        }

        [Route("Create")]
        public async Task<IActionResult> Create(OrderValidationModel orderValidatioModel)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    List<string> messages =
                        ModelState.Values.SelectMany(val => val.Errors.Select(err => err.ErrorMessage))
                        .Where(name => name != "The value '' is invalid.").ToList();

                    HttpContext.Session.SetString("CreateOrder", JsonSerializer.Serialize(orderValidatioModel.Details));

                    return RedirectToAction("Index",
                    new
                    {
                        messages = messages
                    });
                }

                orderValidatioModel.BasketItems = basketService.GetAllBasket();
                await orderService.CreateNewOrder(orderValidatioModel);

                basketService.ClearBasket();

                return RedirectToAction("Message", "SharedConfirmation",
                new
                {
                    message = "You succesfully submitted an order!",
                    confirmUrl = Url.Action("Index", "Home")
                });
            }
            catch
            {
                return RedirectToAction("Message", "SharedConfirmation",
                new
                {
                    message = "Error! Please contact administrator!",
                    confirmUrl = Url.Action("Index", "Home")
                });
            }
        }
    }
}
