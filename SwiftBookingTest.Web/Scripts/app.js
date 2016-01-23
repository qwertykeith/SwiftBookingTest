(function () {
    var app = angular.module('SwiftBookingTestApp', ['ngSanitize']);

    app.factory('SwiftApiService', ['$http', function ($http) {
        var apiRoot = '/SwiftApi';

        var service = {
            bookDelivery: bookDelivery
        };

        return service;

        function bookDelivery(id) {
            return $http.get(apiRoot + '/BookDelivery', { params: { 'id': id } });
        };
    }]);

    app.controller('SwiftApiController', ['$scope', 'SwiftApiService', function ($scope, SwiftApiService) {
        $scope.loading = false;
        $scope.apiResponseData = '';        

        $scope.book = function (id) {
            $scope.loading = true;
            $scope.apiResponseData = '';
            SwiftApiService.bookDelivery(id).then(
                function (response) {
                    $scope.loading = false;
                    $scope.apiResponseData = response.data;                    
                },
                function (response) {
                    $scope.loading = false;
                    $scope.apiResponseData = response.data;
                }
            );
        };
    }]);

    app.run(['$log', function ($log) {
        $log.info('SwiftBookingTestApp started');
    }]);
})();