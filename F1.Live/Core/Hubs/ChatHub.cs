using System.Linq;
using F1.Live.Core.Domain;
using F1.Live.Core.Extensions;
using F1.Live.Core.Services;
using SignalR.Hubs;

namespace F1.Live.Core.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IRepository _repository;

        public ChatHub(IRepository repository)
        {
            _repository = repository;
        }

        public void Init()
        {
            //normally you wouldn't send down domain objects & you would send down the whole batch as list
            _repository.Query<ChatMessage>().OrderByDescending(x => x.Created).Take(3).Each(
                x => Clients[Context.ConnectionId].receiveChat(x));
        }

        public void Send(string message)
        {
            var msg = new ChatMessage() {Message = message};
            _repository.Save(msg);

            Clients.receiveChat(msg);
        }
    }
}