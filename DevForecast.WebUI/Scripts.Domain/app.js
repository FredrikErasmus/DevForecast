(function () {
    var app = angular.module("DevForecast", []);

    var MainController = function ($scope, $http) {
        onForecastsLoaded = function (data) {
            console.log(data);
        };
        $http.get("/api/main/dayforecasts").then(function (data) { onForecastsLoaded(data) });
    };

    app.controller("MainController", ["$scope", "$http", MainController]);

}());