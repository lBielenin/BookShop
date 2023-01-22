using BookShop.Models.PageModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("")]
    public class SharedConfirmationController : Controller
    {
        [Route("Message")]
        public IActionResult Message(
            string confirmUrl,
            string message)
        {
            return View(new MessagePageModel()
            {
                ConfirmUrl = confirmUrl,
                Message = message
            });
        }

        [Route("Confirm")]
        public IActionResult Confirm(
            string confirmUrl,
            string message,
            string rejectUrl,
            string confirmationMethod)
        {
            return View(new ConfirmationPageModel()
            {
                ConfirmationMethod = confirmationMethod,
                ConfirmUrl = confirmUrl,
                Message = message,
                RejectUrl = rejectUrl
            });
        }
    }
}
