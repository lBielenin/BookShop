using BookShop.Models.BasketModels;
using BookShop.Models.Entities;
using BookShop.Models.SessionModels;
using System.Text.Json;

namespace BookShop.Services
{
    public class BasketService : IBasketService
    {
        private IHttpContextAccessor requestAccessor;

        public BasketService(IHttpContextAccessor requestAccessor)
        {
            this.requestAccessor = requestAccessor;
        }

        public void AddToBasket(BasketModel product)
        {
            var basket = GetBasket();
            basket.Items.Add(product);
            SaveBasket(basket);
        }

        public void ClearBasket()
        {
            SaveBasket(new Basket());
        }

        public List<BasketModel> GetAllBasket()
        {
            return GetBasket()?.Items;
        }

        public int GetBasketCount()
        {
            var basket = GetBasket();
            return basket is null ? 0 : basket.Items.Count;
        }

        public void RemoveFromBasket(int productId)
        {
            var basket = GetBasket();
            basket.Items =
                basket.Items.Where(p => p.Id != productId)
                .ToList();

            SaveBasket(basket);
        }

        public void UpdateQuantity(int productId, int newQuantity)
        {
            var basket = GetBasket();
            var item = basket.Items.First(p => p.Id == productId);
            item.Quantity = newQuantity;

            SaveBasket(basket);
        }

        private Basket GetBasket()
        {
            var stringBasket = requestAccessor.HttpContext.Session.GetString(nameof(Basket));
            if (stringBasket is null)
            {
                requestAccessor.HttpContext.Session.SetString(nameof(Basket), JsonSerializer.Serialize(new Basket()));
                stringBasket = requestAccessor.HttpContext.Session.GetString(nameof(Basket));
            }

            return JsonSerializer.Deserialize<Basket>(stringBasket);
        }

        private void SaveBasket(Basket basket)
        {
            requestAccessor.HttpContext.Session.SetString(nameof(Basket), JsonSerializer.Serialize(basket));
        }
    }
}
