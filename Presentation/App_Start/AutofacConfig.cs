using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using System.Web.Http;
using System.Web.Mvc;

namespace Presentation.App_Start
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
            containerBuilder.RegisterApiControllers(typeof(MvcApplication).Assembly).InstancePerRequest();

            containerBuilder.RegisterType<RazvanLivadariuDbContext>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PersonService>().As<IPersonService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CountyService>().As<ICountyService>().InstancePerLifetimeScope();
 
            containerBuilder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<CountyRepository>().As<ICountyRepository>().InstancePerLifetimeScope();

            IContainer autofacContainer = containerBuilder.Build();

            AutofacDependencyResolver mvcDependencyResolver = new AutofacDependencyResolver(autofacContainer);
            AutofacWebApiDependencyResolver webapiDependencyResolver = new AutofacWebApiDependencyResolver(autofacContainer);

            DependencyResolver.SetResolver(mvcDependencyResolver);

            GlobalConfiguration.Configuration.DependencyResolver = webapiDependencyResolver;
        }
    }
}