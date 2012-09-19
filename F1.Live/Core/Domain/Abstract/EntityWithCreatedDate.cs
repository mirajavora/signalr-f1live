using System;
using FluentNHibernate.Data;

namespace F1.Live.Core.Domain.Abstract
{
    public abstract class EntityWithCreatedDate : Entity
    {
        public EntityWithCreatedDate()
        {
            Created = DateTime.Now;
        }
        public virtual DateTime Created { get; set; }
    }
}