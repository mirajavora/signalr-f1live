function Chat() {
    var chatHub = undefined;
    
    var init = function () {
        $(".chat-submit").on("click", sendMessage);
        $(document).on("Connected", function () { chatHub.server.init(); });

        chatHub = $.connection.chatHub;

        chatHub.client.receiveChat = function (value) {
            console.log('Server called addMessage(' + value + ')');
            $("ul.chat-list").prepend($(".chat-template").render(value));
            $("ul.chat-list li:gt(2)").remove();
        };
    };

    var sendMessage = function() {
        chatHub.server.send($(".chat-message").val());
    };

    init();
};