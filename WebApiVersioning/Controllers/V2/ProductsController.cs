using System.Net.Http;
using System.Web.Http;
//using WebApiVersioning.Routing;   // <-- not needed if not subclassing Route
using WebApiVersioning.Models;

namespace WebApiVersioning.Controllers.V2
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/products")]  /* using RoutePrefix */
    public class ProductsController : ApiController
    {
        [Route("", Name = "AddProductRouteV2")]
        [HttpPost]
        public Product AddProduct(HttpRequestMessage reqMessage, Product newProduct)
        {
            return new Product { Id = newProduct.Id, Name = newProduct.Name, Description = "From v2: " + newProduct.Description, Upc = newProduct.Upc };
        }

        [Route("", Name = "GetProductsRouteV2")]
        [HttpGet]
        public Product GetProducts()
        {
            return new Product { Id = 1, Name = "Widget 2.0", Description = "From v2", Upc = "654321123456" };
        }

    }
}
