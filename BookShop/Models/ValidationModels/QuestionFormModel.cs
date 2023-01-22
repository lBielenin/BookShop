using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.ValidationModels
{
    public class QuestionFormModel
    {
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Question field should have length between 1 and 1000!")]
        public string Question { get; set; }
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Name field should have length between 1 and 200!")]
        public string Header { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
