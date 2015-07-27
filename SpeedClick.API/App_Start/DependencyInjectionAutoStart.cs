using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alisson.Core.IoC;
using SimpleInjector.Extensions;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using Alisson.Core.Services.Commands.RegisterUser;

namespace SpeedClick.API
{
    public static class DependencyInjectionAutoStart
    {

        public static void Start()
        {

            DependencyInjectionStarter.container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DependencyInjectionStarter.container);

            DependencyInjectionStarter.container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), typeof(RegisterUserCommandHandler).Assembly);

            DependencyInjectionStarter.Initialize();

            DependencyInjectionStarter.container.Verify();

        }

    }
}