using Microsoft.Practices.Unity;
using ng_table_custom.web.api.App_Start;
using ng_table_custom.web.api.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ng_table_custom.web.api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            AutomapperBootstrap.Register();
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.PerResolve);
        }
    }
}
