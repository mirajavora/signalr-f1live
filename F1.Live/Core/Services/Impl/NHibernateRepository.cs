using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.NHibernateIntegration;
using Castle.Services.Transaction;
using NHibernate;
using NHibernate.Linq;

namespace F1.Live.Core.Services.Impl
{
    [Transactional]
    public class NHibernateRepository : Repository
    {
        private readonly ISessionManager sessionManager;

        public NHibernateRepository(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        protected internal virtual ISession Session
        {
            get
            {
                return sessionManager.OpenSession();
            }
        }

        public override T FindById<T>(object id)
        {
            return Session.Get<T>(id);
        }

        public override T LoadForId<T>(object id)
        {
            return Session.Load<T>(id);
        }

        public override IEnumerable<T> FindAll<T>()
        {
            return Session.CreateCriteria(typeof(T)).Future<T>();
        }

        public override IQueryable<T> Query<T>()
        {
            return Session.Query<T>();
        }

        [Transaction(TransactionMode.Requires)]
        public override void Save<T>(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        [Transaction(TransactionMode.Requires)]
        public override void Delete<T>(T entity)
        {
            Session.Delete(entity);
        }
    }
    
}