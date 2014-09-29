(function () {
    var app = angular.module("DevForecast", ['ui.bootstrap']);

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
        $scope.add = function () {
            
        };
        $scope.getData();
    };

    var AlertDemoController = function ($scope) {
        $scope.alerts = [
          { type: 'danger', msg: 'Oh snap! Change a few things up and try submitting again.' },
          { type: 'success', msg: 'Well done! You successfully read this important alert message.' }
        ];

        $scope.addAlert = function () {
            $scope.alerts.push({ msg: 'Another alert!' });
        };

        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
        };
    };
    app.controller("AlertDemoController", ["$scope", AlertDemoController]);
    app.controller("MainController", ["$scope", "$http", MainController]);

}());