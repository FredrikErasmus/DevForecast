(function () {
    var app = angular.module("DevForecast", []);

    var MainController = function ($scope, $http) {
        $scope.dayForecasts = [];
        $scope.weekForecasts = [];
        $scope.week = [];
        $scope.counter = 0
        onForecastsLoaded = function (response) {
            $scope.dayForecasts = response.data;
            $scope.counter = $scope.dayForecasts.length / 5;
        };
        onWeekForecastsLoaded = function (response) {
            $scope.weekForecasts = response.data;
        };
        onWeekLoaded = function (response) {
            $scope.week = response.data;
        };
        $scope.getData = function () {
            $http.get("/api/dayforecast/dayforecasts").then(onForecastsLoaded);
            $http.get("/api/weekdayforecast/weekdayforecasts").then(onWeekForecastsLoaded);
            $http.get("/api/week/week").then(onWeekLoaded);
        };
        $scope.getData();
    };

    app.controller("MainController", ["$scope", "$http", MainController]);

}());