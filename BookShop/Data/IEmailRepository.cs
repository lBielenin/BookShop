using BookShop.Models.Entities;

namespace BookShop.Data
{
    public interface IEmailRepository
    {
        Task<Email> GetByName(string address);
    }
}