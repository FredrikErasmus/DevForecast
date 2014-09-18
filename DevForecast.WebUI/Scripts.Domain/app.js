(function () {
    var app = angular.module("DevForecast", []);

    var MainController = function ($scope, $http) {
        $scope.testValue = "testValue";
    };

    app.controller("MainController", ["$scope", "$http", MainController]);

}());