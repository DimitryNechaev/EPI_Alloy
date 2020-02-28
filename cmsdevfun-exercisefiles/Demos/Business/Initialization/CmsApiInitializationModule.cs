using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Http;
using System.Web.Routing;

namespace AlloyDemo.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(DependencyResolverInitialization))]
    public class CmsApiInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "CmsApi", 
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}