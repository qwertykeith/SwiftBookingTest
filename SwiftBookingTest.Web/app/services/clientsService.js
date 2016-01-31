swiftApp.service('ClientsService', ['$http', function ($http) {

        this.listClients = function() {
            return $http.get('/api/clients/');
        }

        this.insertClient = function(newClient) {
            return $http.post('/api/clients', newClient);
        }
    }
]);