(function () {
    'use strict';

    /*
     * Maintain client controller
     */
    angular.module('mainModule').controller('AddClientController', AddClientController);

    AddClientController.$inject = ['ClientFactory'];
    /* @ngInject */
    function AddClientController(ClientFactory) {
        var vm = this;
        vm.ClientFactory = ClientFactory;
        
        vm.add = add;

        function add() {

        }
    }

})();