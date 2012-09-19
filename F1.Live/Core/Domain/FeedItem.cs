using F1.Live.Core.Domain.Abstract;

namespace F1.Live.Core.Domain
{
    public class FeedItem : EntityWithCreatedDate
    {
        
        public virtual string Message { get; set; }
        public virtual bool IsPublished { get; set; }
    }
}