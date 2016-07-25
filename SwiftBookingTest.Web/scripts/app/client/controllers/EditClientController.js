(function () {
    'use strict';

    /*
     * Maintain client controller
     */
    angular.module('mainModule').controller('EditClientController', EditClientController);

    EditClientController.$inject = ['ClientFactory', 'Client'];
    /* @ngInject */
    function EditClientController(ClientFactory, Client) {
        var vm = this;
        vm.ClientFactory = ClientFactory;
        vm.client = Client;
    }

})();