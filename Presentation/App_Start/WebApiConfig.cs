using System.Web.Http;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace Presentation.App_Start
#pragma warning restore CA1707 // Identifiers should not contain underscores
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
#pragma warning disable CA1062 // Validate arguments of public methods
                config.Routes.MapHttpRoute(
#pragma warning restore CA1062 // Validate arguments of public methods
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}