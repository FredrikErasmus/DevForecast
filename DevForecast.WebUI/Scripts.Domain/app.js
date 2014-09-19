(function () {
    var app = angular.module("DevForecast", []);

    var MainController = function ($scope, $http) {
        $scope.dayForecasts = [];
        onForecastsLoaded = function (response) {
            $scope.dayForecasts = response.data;
        };
        $http.get("/api/main/dayforecasts").then(onForecastsLoaded);
    };

    app.controller("MainController", ["$scope", "$http", MainController]);

}());