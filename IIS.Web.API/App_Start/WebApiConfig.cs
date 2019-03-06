using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace IIS.Web.API.App_Start
{
    public class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();

            config.EnableCors();

            //Web Api Routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("application/json"));

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();

            return config;
        }
    }
}