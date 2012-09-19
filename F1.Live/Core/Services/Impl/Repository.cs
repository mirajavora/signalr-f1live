using System.Collections.Generic;
using System.Linq;

namespace F1.Live.Core.Services.Impl
{
    public abstract class Repository : IRepository
    {
        public abstract T FindById<T>(object id);
        public abstract T LoadForId<T>(object id);
        public abstract IEnumerable<T> FindAll<T>();
        public abstract IQueryable<T> Query<T>() where T : class;
        public abstract void Save<T>(T entity);
        public abstract void Delete<T>(T entity);
    }
}