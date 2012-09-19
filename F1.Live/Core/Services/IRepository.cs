using System.Collections.Generic;
using System.Linq;

namespace F1.Live.Core.Services
{
    public interface IRepository
    {
        T FindById<T>(object id);

        T LoadForId<T>(object id);

        IEnumerable<T> FindAll<T>();

        IQueryable<T> Query<T>() where T : class;

        void Save<T>(T entity);

        void Delete<T>(T entity);
    }
}