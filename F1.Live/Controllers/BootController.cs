using System;
using System.Web.Mvc;
using F1.Live.Core.Config;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace F1.Live.Controllers
{
    public class BootController : Controller
    {
        private readonly NhibernateConfiguration _config;

        public BootController(NhibernateConfiguration config)
        {
            _config = config;
        }

        public ActionResult Index()
        {
            CreateDatabase();
            return Content("OK");
        }

        protected void CreateDatabase()
        {
            NHibernate.Cfg.Configuration configuration = _config.GetConfiguration();
            var session = configuration.BuildSessionFactory().OpenSession();
            CreateSchema(configuration, session);
        }

        private void CreateSchema(NHibernate.Cfg.Configuration configuration, ISession session)
        {
            new SchemaExport(configuration).Execute(true, true, false, session.Connection, Console.Out);
        }
    }
}