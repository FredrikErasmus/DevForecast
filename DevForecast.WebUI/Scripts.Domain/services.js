(function () {
    var services = angular.module("DevForecast.Services", ['ngResource']);
    services.factory('Scheduler', ['$resource', function ($resource) {
        return $resource('api/schedule/:scheduleId', { scheduleId: '@scheduleId' }, {
            //query: { method: 'GET', params: {}, isArray: true }
            getWeekDayForecasts: { url: 'api/weekdayforecast/weekdayforecasts', isArray: true },
            getDayForecasts: { url: 'api/dayforecast/dayforecasts', isArray: true }
        });
    }]);
    services.factory('TimeSheet', ['$resource', function ($resource) {
        return $resource('api/timesheet/:timesheetId', { timesheetId: '@timesheetId' }, {
            postFile: { url: 'api/timesheet/postfile', method: 'POST' }
        });
    }]);
}());