using BookShop.Data;
using BookShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("UserOrders")]
    public class UserOrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        private readonly UserManager<IdentityUser> userManager;

        public UserOrdersController(
            IOrderService orderService,
            UserManager<IdentityUser> userManager,
            IProductService productService)
        {
            this.orderService = orderService;
            this.userManager = userManager;
            this.productService = productService;
        }

        [Authorize]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            if(User is null)
            {
                RedirectToAction("Index", "Index");
            }
            string? email = await userManager.GetEmailAsync(await userManager.GetUserAsync(User));
            IEnumerable<Models.Entities.Order>? orders = await orderService.GetOrdersByEmail(email);

            return View(orders.OrderByDescending(o => o.CreationDate));
        }
    }
}
