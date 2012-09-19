using System.Linq;
using F1.Live.Core.Domain;
using F1.Live.Core.Extensions;
using F1.Live.Core.Services;
using SignalR.Hubs;

namespace F1.Live.Core.Hubs
{
    public class FeedHub : Hub
    {
        private readonly IRepository _repository;

        public FeedHub(IRepository repository)
        {
            _repository = repository;
        }

        public void Init()
        {
            //normally you wouldn't send down domain objects & you would send down the whole batch as list
            _repository.Query<FeedItem>().Where(x => x.IsPublished).OrderByDescending(x => x.Created).Take(2).Each(
                x => Clients[Context.ConnectionId].receive(x));
        }
    }
}