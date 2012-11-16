function Feed() {
    var feedHub = undefined;

    var init = function () {
        feedHub = $.connection.feedHub;
        $(document).on("Connected", function () { feedHub.server.init(); });

        feedHub.client.receive = function (item) {
            var selector = "ul.feed-list li[data-id=" + item.Id + "]";
            if (!($(selector).length > 0)) {
                $("ul.feed-list").prepend($(".feed-template").render(item));
                $("ul.feed-list li:gt(3)").remove();
            }
        };
    };

    init();
};