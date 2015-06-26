using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using WebApiVersioning.Routing;
using WebApiVersioning.Infrastructure;
using System.Net.Http.Formatting;

namespace WebApiVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //// http://stackoverflow.com/questions/12976352/asp-net-web-api-model-binding-not-working-with-xml-data-on-post
            //config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // force JSON-only
            var jsonFormatter = new JsonMediaTypeFormatter();
            //optional: set serializer settings here
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            // replace default namespace-unaware controller selector
            ConfigureRouting(config);
        }

        private static void ConfigureRouting(HttpConfiguration config)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();
            // 
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Services.Replace(typeof(IHttpControllerSelector),
                new NamespaceHttpControllerSelector(config));            
        }
    }
}
