using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Hubs;

namespace F1.Live.Core.Hubs
{
    public class LeaderboardHub : Hub
    {
        public void PublishLeaderboard(IList<object> leaderboard)
        {
            Clients.All.receive(leaderboard);
        }
    }
}