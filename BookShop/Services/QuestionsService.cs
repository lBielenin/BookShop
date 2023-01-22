using BookShop.Models.ValidationModels;

namespace BookShop.Services
{
    public class QuestionsService : IQuestionsService
    {
        public Task PostQuestion(QuestionFormModel model)
        {
            return Task.CompletedTask;
        }
    }
}
