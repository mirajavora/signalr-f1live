using System.Web.Mvc;
using F1.Live.Core.Domain;
using F1.Live.Core.Hubs;
using F1.Live.Core.Services;
using F1.Live.Models;
using Microsoft.AspNet.SignalR;

namespace F1.Live.Controllers
{
    public class ManageController : Controller
    {
        private readonly IRepository _repository;

        public ManageController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var model = new ManageModel() {Items = _repository.FindAll<FeedItem>()};
            return View(model);
        }

        public ActionResult Add()
        {
            var model = new AddFeedItemModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddFeedItemModel model)
        {
            var update = new FeedItem() {Message = model.Content};
            _repository.Save(update);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long feedItemId)
        {
            var item = _repository.FindById<FeedItem>(feedItemId);
            _repository.Delete(item);

            return RedirectToAction("Index");
        }

        public ActionResult Publish(long feedItemId)
        {
            var myHub = GlobalHost.ConnectionManager.GetHubContext<FeedHub>();

            var item = _repository.FindById<FeedItem>(feedItemId);
            item.IsPublished = true;
            _repository.Save(item);

            var result = myHub.Clients.All.receive(item);
            return RedirectToAction("Index");
        }
    }
}