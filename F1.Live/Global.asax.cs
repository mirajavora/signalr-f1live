using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using F1.Live.App_Start;
using F1.Live.Core.Config;
using F1.Live.Core.Install;
using SignalR;

namespace F1.Live
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = CreateContainer();

            //resolve controllers
            var factory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(factory);

            //resolve hubs
            var signalrDependency = new SignalrDependencyResolver(container.Kernel);
            GlobalHost.DependencyResolver = signalrDependency;
            RouteTable.Routes.MapHubs(signalrDependency);


            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();
            container.Install(new PersistenceInstaller());
            container.Install(new ServicesInstaller());
            container.Install(new ControllersInstaller());
            container.Install(new HubsInstaller());

            return container;
        }
    }
}