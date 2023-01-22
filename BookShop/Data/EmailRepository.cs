using BookShop.Models.Entities;

namespace BookShop.Data
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext context;

        public EmailRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Email> GetByName(string address)
        {
            return context.Emails.FirstOrDefault(email => email.EmailAddress == address);
        }
    }
}
