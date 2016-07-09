(function () {
    'use strict';

    /*
     * Maintain client controller
     */
    angular.module('mainModule').controller('GetClientController', GetClientController);

    GetClientController.$inject = ['ClientFactory', 'Client'];
    /* @ngInject */
    function GetClientController(ClientFactory, Client) {
        var vm = this;
        vm.ClientFactory = ClientFactory;
        vm.client = Client;
    }

})();