using System;
using F1.Live.Core.Domain.Abstract;
using FluentNHibernate.Data;

namespace F1.Live.Core.Domain
{
    public class ChatMessage : EntityWithCreatedDate
    {
        public virtual string Message { get; set; }
    }
}