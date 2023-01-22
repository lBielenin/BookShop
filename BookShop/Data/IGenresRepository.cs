using BookShop.Models.Entities;

namespace BookShop.Data
{
    public interface IGenresRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int id);
    }
}