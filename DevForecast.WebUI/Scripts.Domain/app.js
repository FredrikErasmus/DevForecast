(function () {
    var app = angular.module("DevForecast", []);

    var MainController = function ($scope, $http) {
        $scope.dayForecasts = [];
        $scope.weekForecasts = [];
        $scope.counter = 0
        onForecastsLoaded = function (response) {
            $scope.dayForecasts = response.data;
            $scope.counter = $scope.dayForecasts.length / 5;
        };
        onWeekForecastsLoaded = function (response) {
            $scope.weekForecasts = response.data;
        };
        $scope.getData = function () {
            $http.get("/api/dayforecast/dayforecasts").then(onForecastsLoaded);
            $http.get("/api/weekdayforecast/weekdayforecasts").then(onWeekForecastsLoaded);
        };
        $scope.getData();
    };

    app.controller("MainController", ["$scope", "$http", MainController]);

}());