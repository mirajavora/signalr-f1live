using Microsoft.AspNet.SignalR.Hubs;

namespace F1.Live.Core.Hubs
{
    public class ImagesHub : Hub
    {
        public void PublishPhoto(string url)
        {
            Clients.All.receive(url);
        }
    }
}