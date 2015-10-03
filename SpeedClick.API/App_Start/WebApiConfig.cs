using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using SpeedClick.Logic.Database;
using System.Net.Http.Headers;
using System.Web.Http.Cors;
using SpeedClick.Logic.Services.RankingCalculator;

namespace SpeedClick.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Cors
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html") );

            AutoMapperBootstrapper.Configure(new ScoreRankingCalculator());

            DependencyInjectionAutoStart.Start();

            ConnectionConfigSI.configure();


        }
    }
}
