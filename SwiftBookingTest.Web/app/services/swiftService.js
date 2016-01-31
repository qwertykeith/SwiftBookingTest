swiftApp.service('SwiftService', [
    '$http', function($http) {
        this.bookDelivery = function(clientId) {
            return $http.post('/api/swift/deliveries/' + clientId, null);
        }
    }
]);