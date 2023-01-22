using BookShop.Models.SessionModels;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("Basket")]
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var items = basketService.GetAllBasket();

            return View(items);
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            basketService.RemoveFromBasket(id);

            return RedirectToAction("Index");
        }

        [Route("UpdateQuantity")]
        [HttpPost]
        public void UpdateQuantity(int id, int newQuantity)
        {
            basketService.UpdateQuantity(id, newQuantity);

        }
    }
}
