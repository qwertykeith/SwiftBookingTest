swiftApp.controller('BookingController', [
    '$scope', 'ClientsService', function($scope, clientSvc) {
        $scope.hasApiError = false;
        $scope.hasApiResult = false;

        $scope.clientsList = [];

        $scope.newClient = {
            Name: null,
            PrimaryPhone: null,
            Address: null
        };

        $scope.addPerson = function () {
            clientSvc.insertClient($scope.newClient)
                .success(function(data) {
                    $scope.clientsList.push(data);
                    $scope.hasApiResult = true;
                    $scope.hasApiError = false;
                })
                .error(function (data) {
                    $scope.hasApiResult = true;
                    $scope.hasApiError = true;
                });
        }


        clientSvc.listClients()
            .success(function(data, status) {
                $scope.clientsList.concat(data);
            });


    }
]);