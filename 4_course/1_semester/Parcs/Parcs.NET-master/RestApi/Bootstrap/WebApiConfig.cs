using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using Unity.WebApi;

namespace RestApi.Bootstrap
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IUnityContainer unityContainer)
        {
            config.DependencyResolver = new UnityDependencyResolver(unityContainer);

            // Serialize with camelCase formatter for JSON.
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional, action = RouteParameter.Optional });

            ODataConfig.RegisterLogEntryEndpoint(config);

            //Deny all unAuthorized access to WebApi except explicit AllowAnonymous attribute
            //TODO: uncomment when auth is implemented properly
            //config.Filters.Add(new AuthorizeAttribute());
        }
    }
}