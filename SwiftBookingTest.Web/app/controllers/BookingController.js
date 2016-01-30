swiftApp.controller('BookingController', function ($scope) {
    $scope.hasApiError = false;
    $scope.hasApiResult = false;

    $scope.newPerson = {
        Name: null,
        PrimaryPhone: null,
        Address: null
    };

    $scope.clientsList = [
        {
            Name: 'Test Name',
            PrimaryPhone: '0400 123 456',
            PickupAddress: '1 Bourke St, Melbourne 3000',
            DeliveryAddress: '2 Bourke St, Melbourne 3000'
        },
        {
            Name: 'Test Name',
            PrimaryPhone: '0400 123 456',
            PickupAddress: '1 Bourke St, Melbourne 3000',
            DeliveryAddress: '2 Bourke St, Melbourne 3000'
        }
    ];
});