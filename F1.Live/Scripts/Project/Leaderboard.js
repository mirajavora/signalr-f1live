function Leaderboard() {
    var leaderboardHub = undefined;
    
    var init = function() {
        leaderboardHub = $.connection.leaderboardHub;

        leaderboardHub.client.receive = function (value) {
            console.log('received Leaderboard (' + value + ')');
            $(".leaderboard").html($(".leaderboard-template").render({ Items: value }));
        };
    };

    init();
};