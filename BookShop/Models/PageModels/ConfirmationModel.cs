namespace BookShop.Models.PageModels
{
    public class ConfirmationPageModel : MessagePageModel
    {
        public string RejectUrl { get; set; }
        public string ConfirmationMethod { get; set; }
    }
}
