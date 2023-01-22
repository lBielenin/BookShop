using BookShop.Models.ValidationModels;

namespace BookShop.Services
{
    public interface IOrderService
    {
        Task CreateNewOrder(OrderValidationModel orderValidatioModel);
    }
}
