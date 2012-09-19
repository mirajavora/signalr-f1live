using Castle.Core.Configuration;
using Castle.Facilities.NHibernateIntegration;

namespace F1.Live.Core.Config
{
    public class FluentNHibernateConfigurationBuilder : IConfigurationBuilder
    {
        private readonly NhibernateConfiguration _nhibernateConfiguration;

        public FluentNHibernateConfigurationBuilder(NhibernateConfiguration nhibernateConfiguration)
        {
            _nhibernateConfiguration = nhibernateConfiguration;
        }

        public global::NHibernate.Cfg.Configuration GetConfiguration(IConfiguration config)
        {
            return _nhibernateConfiguration.GetConfiguration();
        }
    }
}