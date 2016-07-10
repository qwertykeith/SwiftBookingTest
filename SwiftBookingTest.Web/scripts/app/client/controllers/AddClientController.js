(function () {
    'use strict';

    /*
     * Maintain client controller
     */
    angular.module('mainModule').controller('AddClientController', AddClientController);

    AddClientController.$inject = ['ClientFactory', '$scope'];
    /* @ngInject */
    function AddClientController(ClientFactory, $scope) {
        var vm = this;
        vm.ClientFactory = ClientFactory;
        vm.setRating = setRating;

       

        function setRating() {

        }
    }

})();