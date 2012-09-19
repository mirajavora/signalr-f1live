using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SignalR.Hubs;

namespace F1.Live.Core.Install
{
    public class HubsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromAssembly(typeof(MvcApplication).Assembly)
                    .BasedOn<Hub>().Configure(
                        x => x.Named(x.Implementation.FullName.ToLower()).LifeStyle.Transient));
        }
    }
}