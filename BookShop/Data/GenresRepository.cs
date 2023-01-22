using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class GenresRepository : IGenresRepository 
    { 
        private readonly ApplicationDbContext _dbContext;

        public GenresRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public Task<Genre> GetGenreById(int id)
        {
            return _dbContext.Genres.FirstAsync(gen => gen.Id == id);
        }
    }
}
