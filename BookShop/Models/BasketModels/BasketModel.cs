namespace BookShop.Models.BasketModels
{
    public class BasketModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public int Quantity { get; set; }
    }
}
