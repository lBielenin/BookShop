using BookShop.Models.BasketModels;

namespace BookShop.Services
{
    public interface IBasketService
    {
        public List<BasketModel> GetAllBasket();
        public int GetBasketCount();
        public void AddToBasket(BasketModel product);
        public void RemoveFromBasket(int productId);
        public void UpdateQuantity(int productId, int newQuantity);
        void ClearBasket();
    }
}