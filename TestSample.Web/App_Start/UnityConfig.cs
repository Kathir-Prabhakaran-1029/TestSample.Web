using System.Web.Mvc;
using TestSample.Persistance.DBConnectionFactory;
using TestSample.Persistance.Implementation;
using TestSample.Persistance.Interface;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace TestSample.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDbConnectionFactory, DbConnectionFactory>(new InjectionConstructor(new object[] { "SampleDB" }));
            container.RegisterType<IInsurerDao, InsurerDao>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}