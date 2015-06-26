using System.Net.Http;
using System.Web.Http;
using WebApiVersioning.Routing;
using WebApiVersioning.Models;

namespace WebApiVersioning.Controllers.V1
{
    [ApiVersion1RoutePrefix("products")]    /* matches route "~/api/{version}/products */
    public class ProductsController : ApiController
    {
        [Route("", Name = "AddProductRoute")]
        [HttpPost]
        public Product AddProduct(HttpRequestMessage reqMessage, Product newProduct)
        {
            return new Product { Id = 1, Name = "Widget", Description = "From v1", Upc = "123456654321" };
        }

        [Route("", Name = "GetProductsRoute")]
        [HttpGet]
        public Product GetProducts()
        {
            return new Product { Id = 1, Name = "Widget", Description = "From v1", Upc = "123456654321" };
        }
    }
}
