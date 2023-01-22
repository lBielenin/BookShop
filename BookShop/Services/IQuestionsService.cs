using BookShop.Models.ValidationModels;

namespace BookShop.Services
{
    public interface IQuestionsService
    {
        Task PostQuestion(QuestionFormModel model);
    }
}
