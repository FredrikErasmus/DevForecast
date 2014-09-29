(function () {
    var app = angular.module("DevForecast", ['ngResource', 'DevForecast.Services', 'ui.bootstrap']);

    var MainController = function ($scope, $http, $resource, Scheduler, TimeSheet) {
        $scope.dayForecasts = [];
        $scope.weekForecasts = [];
        $scope.week = [];
        $scope.counter = 0;
        $scope.uploadStatus = '';
        $scope.onWeekForecastsLoaded = function (response) {
            $scope.weekForecasts = response;
        };
        $scope.getWeekDayForecasts = function () {
            Scheduler.getWeekDayForecasts().$promise.then($scope.onWeekForecastsLoaded);
        };
        $scope.upload = function () {
            var fd = new FormData();
            for (var i = 0; i < document.getElementById('files').files.length; i++) {
                fd.append("files", document.getElementById('files').files[i]);
            }
            var xhr = new XMLHttpRequest();
            xhr.addEventListener("load", uploadComplete, false);
            xhr.upload.addEventListener("progress", uploadProgress, false);
            xhr.open("POST", "api/timesheet/postfile");
            xhr.send(fd);            
        };
        $scope.getWeekDayForecasts();
    };
    app.controller("MainController", ["$scope", "$http", '$resource', 'Scheduler', 'TimeSheet', MainController]);
}());

function uploadComplete(evt) {
    /* This event is raised when the server send back a response */
    //alert(evt.target.responseText);
    console.log(evt.target.responseText);
};
function uploadProgress(evt) {
    if (evt.lengthComputable) {
        var percentComplete = Math.round(evt.loaded * 100 / evt.total);
        //document.getElementById('progressNumber').innerHTML = percentComplete.toString() + '%';
        console.log(percentComplete);
    }
    else {
        //document.getElementById('progressNumber').innerHTML = 'unable to compute';
        console.log('unable to compute');
    }
}