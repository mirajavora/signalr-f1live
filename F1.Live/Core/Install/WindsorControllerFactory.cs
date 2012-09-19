using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace F1.Live.Core.Install
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //controllers
            container.Register(
                AllTypes.FromAssembly(typeof(MvcApplication).Assembly)
                    .BasedOn<IController>().Configure(
                        x => x.Named(x.Implementation.FullName.ToLower()).LifeStyle.Transient));
        }
    }
}