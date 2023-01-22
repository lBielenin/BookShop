using BookShop.Models.Entities;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers.API
{
    [Route("api/Products")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductApiController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await productService.GetProduct(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await productService.CreateNewProduct(product);

        }

        [HttpPut("{id}")]
        public async void Put([FromBody] Product product)
        {
            await productService.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await productService.DeleteProduct(id);

        }
    }
}
