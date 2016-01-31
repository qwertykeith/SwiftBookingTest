swiftApp.controller('BookingController', [
    '$scope', 'ClientsService', 'SwiftService', function($scope, clientSvc, swiftSvc) {
        $scope.hasApiError = false;
        $scope.result = null;

        $scope.clientsList = [];

        $scope.newClient = {
            Name: null,
            Phone: null,
            Address: null
        };

        $scope.addPerson = function () {
            clientSvc.insertClient($scope.newClient)
                .success(function(data) {
                    $scope.clientsList.push(data);
                })
                .error(function(data) {
                    $scope.result = data.message;
                    $scope.hasApiError = true;
                });
        }

        $scope.bookDelivery = function(clientId) {
            swiftSvc.bookDelivery(clientId)
                .success(function(apiData) {
                    $scope.result = apiData;
                    $scope.hasApiError = false;
                })
                .error(function(data) {
                    $scope.result = data.message;
                    $scope.hasApiError = true;
                });
        }

        clientSvc.listClients()
            .success(function(data, status) {
                $scope.clientsList = $scope.clientsList.concat(data);
            });
    }
]);