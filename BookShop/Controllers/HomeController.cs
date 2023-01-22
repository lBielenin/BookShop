using BookShop.Models;
using BookShop.Models.Entities;
using BookShop.Models.SessionModels;
using BookShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace BookShop.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IBasketService basketService;

        public HomeController(
            ILogger<HomeController> logger, 
            IProductService productService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IBasketService basketService)
        {
            _logger = logger;
            _productService = productService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.basketService = basketService;
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            //if(User is not null)
            //{
            //    await roleManager.CreateAsync(new IdentityRole()
            //    {
            //        Name = "Administrator",
            //        NormalizedName = "Administrator"
            //    });
            //    var user = await userManager.GetUserAsync(User);
            //    await userManager.AddToRoleAsync(user, "Administrator");
            //}

            List<Product> data = await _productService.GetProducts();
            return View(data);
        }
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await _productService.GetProduct(productId);
            basketService.AddToBasket(product.ToBasketModel());

            return RedirectToAction(nameof(Index));
        }

        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}