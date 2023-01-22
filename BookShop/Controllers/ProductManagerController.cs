using BookShop.Models.Entities;
using BookShop.Models.PageModels;
using BookShop.Models.ValidationModels;
using BookShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace BookShop.Controllers
{
    [Route("ProductManager")]
    public class ProductManagerController : Controller
    {
        private readonly IProductService productService;

        public ProductManagerController(IProductService productService)
        {
            this.productService = productService;
        }

        [Route("")]
        public async Task<ActionResult> Index()
        {
            List<Product>? products =
                await productService.GetProducts();

            return View(products);
        }


        [HttpGet("Create")]
        public async Task<ActionResult> Create(IEnumerable<string> messages = null)
        {
            ProductValidationModel model = null;
            if(messages is not null && messages.Count() > 0)
            {
                ViewBag.ErrorMessages = messages;
                model = JsonSerializer.Deserialize<ProductValidationModel>(HttpContext.Session.GetString("CreateProduct"));

            }

            List<Genre>? genres = await productService.GetGenres();
            ViewBag.Genres = new SelectList(genres, "Id", "Name");

            return View(model);
        }
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductValidationModel product)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    IEnumerable<string> messages = 
                        ModelState.Values.SelectMany(val => val.Errors.Select(err => err.ErrorMessage));

                    HttpContext.Session.SetString("CreateProduct",JsonSerializer.Serialize(product));

                    return RedirectToAction("Create",
                    new
                    {
                        messages = messages,
                        model = product
                    });
                }
                await productService.CreateNewProduct(product);

                return RedirectToAction("Message", "SharedConfirmation", 
                    new { message = "You succesfully created new product!",
                          confirmUrl = Url.Action("Index", "ProductManager")
                    });
            }
            catch
            {
                return View();
            }
        }

        [Route("Created")]
        public ActionResult ProductCreated()
        {
            return View();
        }

        [HttpGet("Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            var product = await productService.GetProduct(id);
            List<Genre>? genres = await productService.GetGenres();
            var pickedIndex = genres.IndexOf(genres.First(g => g.Id == product.ProductDetail.Genre.Id));
            ViewBag.Genres = new SelectList(genres, "Id", "Name", pickedIndex);

            var valid = product.ToProductValidationModel();
            return View(valid);
        }

        [HttpPost("Edit")]
        public async Task<ActionResult> Edit(ProductValidationModel product)
        {
            if(ModelState.IsValid)
            {
                await productService.UpdateProduct(product);

            }
            return View();
        }

        // POST: ProductController/Edit/5

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var confirmUrl = Url.Action($"/Delete/{id}");
            return RedirectToAction("Confirm", "SharedConfirmation",
                new
                {
                    message = "Are You sure you want to delete this product?",
                    confirmUrl = $"/ProductManager/Delete/{id}",
                    rejectUrl = Url.Action("Index"),
                    confirmationMethod = "post"
                });
        }

        [HttpPost("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {

                return RedirectToAction("Message", "SharedConfirmation",
                    new
                    {
                        message = "You succesfully deleted new product!",
                        confirmUrl = Url.Action("Index", "ProductManager")
                    });
            }
            catch
            {
                return View();
            }
        }
    }
}
