using System.Collections.Generic;
using Castle.Core.Configuration;
using Castle.Facilities.AutoTx;
using Castle.Facilities.NHibernateIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using F1.Live.Core.Config;
using FluentNHibernate.Automapping;
using Rhino.Commons.Binsor.Configuration;

namespace F1.Live.Core.Install
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAutomappingConfiguration>().ImplementedBy<DefaultAutomappingConfiguration>());

            RegisterAutomappingConfiguration(container);
            RegisterTransactionFacility(container);
            RegisterNHibernateConfiguration(container);
            RegisterNHibernateFacility(container);
        }

        private void RegisterAutomappingConfiguration(IWindsorContainer container)
        {
            container.Register(Component.For<IAutomappingConfiguration>().ImplementedBy<F1AutomappingConvention>());
        }

        protected void RegisterNHibernateFacility(IWindsorContainer container)
        {
            container.Kernel.ConfigurationStore.AddFacilityConfiguration("nhibernateIntegration", Build());
            container.AddFacility("nhibernateIntegration", new NHibernateFacility());
        }

        protected void RegisterTransactionFacility(IWindsorContainer container)
        {
            container.AddFacility<TransactionFacility>();
        }

        protected void RegisterNHibernateConfiguration(IWindsorContainer container)
        {
            container.Register(Component.For<NhibernateConfiguration>()
                                   .ImplementedBy<NhibernateConfiguration>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<Castle.Facilities.NHibernateIntegration.IConfigurationBuilder>().ImplementedBy<FluentNHibernateConfigurationBuilder>().LifeStyle.Singleton);
        }


        private IConfiguration Build()
        {
            var configuration = ConfigurationHelper.CreateConfiguration(null, "facility", new Dictionary<string, object>());
            configuration.Attributes.Add("isWeb", true.ToString());
            var factoryConfig = ConfigurationHelper.CreateConfiguration(configuration, "factory", new Dictionary<string, object>());
            factoryConfig.Attributes.Add("Id", "factory_1");
            factoryConfig.Attributes.Add("factory_1.configurationBuilder", typeof(FluentNHibernateConfigurationBuilder).FullName);
            return configuration;
        }
    }
}