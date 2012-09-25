function Photos() {
    var imagesHub = undefined;
    
    var init = function() {
        imagesHub = $.connection.imagesHub;

        imagesHub.receive = function (value) {
            $(".images").html($(".image-template").render({ Image: value }));
        };
    };

    init();
};