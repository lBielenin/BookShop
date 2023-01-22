using BookShop.Models.BasketModels;

namespace BookShop.Models.SessionModels
{
    public class Basket
    {
        public List<BasketModel> Items { get; set; } = new ();
    }
}
