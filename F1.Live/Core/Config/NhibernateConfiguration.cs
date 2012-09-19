using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace F1.Live.Core.Config
{
    public class NhibernateConfiguration
    {
        public virtual global::NHibernate.Cfg.Configuration GetConfiguration()
        {
            var cfg = GetFluentConfiguration();
            return cfg.BuildConfiguration();
        }

        private FluentConfiguration GetFluentConfiguration()
        {
            var config = Fluently.Configure();
            var automap = ConfigureAutoMap();

            var persistenceConfigurer = GetConnection();
            config.Database(persistenceConfigurer).Mappings(map => map.AutoMappings.Add(automap));
            return config;
        }

        private AutoPersistenceModel ConfigureAutoMap()
        {
            var autoMap = AutoMap.AssemblyOf<MvcApplication>(new F1AutomappingConvention());
            return autoMap;

        }

        private IPersistenceConfigurer GetConnection()
        {
            return MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c.FromConnectionStringWithKey("Default"))
                .AdoNetBatchSize(100)
                .FormatSql();
        }
    }
}