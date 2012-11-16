/// <reference path="../jquery-1.7.2.min.js" />
/// <reference path="../jquery.signalR-1.0.0-alpha2.min.js" />


function Photos() {
    var imagesHub = undefined;
    
    var init = function() {
        imagesHub = $.connection.imagesHub;

        imagesHub.client.receive = function (value) {
            $(".images").html($(".image-template").render({ Image: value }));
        };
    };

    init();
};