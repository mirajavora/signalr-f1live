using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using F1.Live.Core.Services;
using F1.Live.Core.Services.Impl;

namespace F1.Live.Core.Install
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<Castle.Facilities.FactorySupport.FactorySupportFacility>();
            container.Register(Component.For<IRepository>().ImplementedBy<NHibernateRepository>().LifeStyle.Transient);
        }
    }
}