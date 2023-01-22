using BookShop.Models.ValidationModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("Questions")]
    public class QuestionsController : Controller
    {
        [HttpGet("")]
        public IActionResult Index(IEnumerable<string> messages = null)
        {
            if(messages is not null && messages.Any())
            {
                ViewBag.ErrorMessages = messages;
            }
            return View();
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(QuestionFormModel model) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<string> messages =
                        ModelState.Values.SelectMany(val => val.Errors.Select(err => err.ErrorMessage));

                    return RedirectToAction("Index",
                    new
                    {
                        messages = messages
                    });
                }

                return RedirectToAction("Message", "SharedConfirmation",
                    new
                    {
                        message = "You have successfully sent a question! Answer will come to your email. Someday.",
                        confirmUrl = Url.Action("Index", "Home")
                    });
            }
            catch
            {
                return View();
            }
        }
    }
}
