using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using SignalR.Client.Hubs;

namespace F1.Service
{
    public partial class Form1 : Form
    {
        private HubConnection _connection;
        private IList<dynamic> _leaderboard;
        private IList<string> _photos;
        private int _photoIndex;
        private IHubProxy _leaderboardHub;
        private IHubProxy _imageHub;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        //please ignore the quality of the code ...
        private void Init()
        {
            AddItem("Service started", "OK");
            var instagramTimer = new Timer();
            var leaderboardTimer = new Timer();

            //create proxy
            _connection = new HubConnection(EndPointUrl.Text);
            _leaderboardHub = _connection.CreateProxy("LeaderboardHub");
            _imageHub = _connection.CreateProxy("ImagesHub");
            _connection.Start();
            
            AddItem("Connection State", _connection.State.ToString());

            //init leaderboard
            _leaderboard = CreateLeaderboard();
            _photos = GetPhotos();
            _photoIndex = 0;

            //init timers
            instagramTimer.Interval = 10000;
            instagramTimer.Tick +=  InstagramElapsed;
            leaderboardTimer.Interval = 5000;
            leaderboardTimer.Tick += LeaderboardElapsed;

            instagramTimer.Start();
            leaderboardTimer.Start();
        }

        private IList<dynamic> CreateLeaderboard()
        {
            var leaders = new List<dynamic>();
            var names = new List<string>()
                            {
                                "Lewis Hamilton",
                                "Jensen Button",
                                "Fernando Alonso",
                                "Felipe Massa",
                                "Sebastien Vettel",
                                "Michael Schumacher",
                                "Nico Roseberg",
                                
                            };
            for (var i = 1; i < 7; i++)
            {
                leaders.Add(CreateLeaderboardItem(names[i-1], i));
            }

            return leaders;
        }

        private object CreateLeaderboardItem(string name, int position)
        {
            return new {Name = name, Position = position, PositionChange = 0};

        }

        void LeaderboardElapsed(object sender, EventArgs e)
        {
            AddItem("Connection State", _connection.State.ToString());

            _leaderboardHub.Invoke("PublishLeaderboard", GetLeaderboard()).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    AddItem("Leaderboard", string.Format("An error occurred during the method call {0}", task.Exception.GetBaseException()));
                }
                else
                {
                    AddItem("Leaderboard", "Successfully called PublishLeaderboard");

                }
            });
        }

        private void InstagramElapsed(object sender, EventArgs e)
        {
            if (_photoIndex >= _photos.Count)
                _photoIndex = 0;

            var image = _photos[_photoIndex];

            _imageHub.Invoke("PublishPhoto", image).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    AddItem("Instagram", string.Format("An error occurred during the method call {0}", task.Exception.GetBaseException()));
                }
                else
                {
                    AddItem("Instagram", image);

                }
            });
            _photoIndex++;
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            //create proxy
            _connection = new HubConnection(EndPointUrl.Text);
            _connection.Start();
        }

        private void AddItem(string action, string result)
        {
            var item = new ListViewItem(new[] {action, DateTime.Now.ToString(), result});
            ListData.Items.Add(item);
        }

        private IList<dynamic> GetLeaderboard()
        {
            //clear position change property
            for (int index = 0; index < _leaderboard.Count; index++)
            {
                var o = _leaderboard[index];
                _leaderboard[index] = new {Name = o.Name, Position = o.Position, PositionChange = 0};
            }

            //swap two places
            var total = _leaderboard.Count;
            var rnd = new Random();
            var swapIndex = rnd.Next(0, total - 2);

            var original = _leaderboard[swapIndex];
            var next = _leaderboard[swapIndex + 1];

            _leaderboard[swapIndex + 1] = new { Name = original.Name, Position = original.Position, PositionChange = 1 }; ;
            _leaderboard[swapIndex] = new { Name = next.Name, Position = next.Position, PositionChange = -1 }; ; ;

            return _leaderboard;
        }


        private IList<string> GetPhotos()
        {
            var photos = new List<string>();
            try
            {
                var config = new InstaSharp.InstagramConfig("https://api.instagram.com/v1", "https://api.instagram.com/oauth", "ec801d2b6eff42aaa5dc1d18bfc5e74b", "9c2aa521f5df4019b298a816bcfd4a4c", "http://localhost:56137/");
                var tagSearch = new InstaSharp.Endpoints.Tags.Unauthenticated(config);
                var searchResults = tagSearch.Recent(HttpUtility.UrlEncode("f1"));

                photos.AddRange(searchResults.Data.Select(x => x.Images.LowResolution.Url).ToList());

                return photos;
            }
            catch (Exception ex)
            {
                //load the fake photos
                //todo
                photos.Add("http://google.com/image.jpg");
            }
            return photos;
        }
    }
}
