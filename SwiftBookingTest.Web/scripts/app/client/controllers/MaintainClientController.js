(function () {
    'use strict';

    /*
     * Maintain client controller
     */
    angular.module('mainModule').controller('MaintainClientController', MaintainClientController);

    MaintainClientController.$inject = ['ClientFactory', 'ClientRecords'];
    /* @ngInject */
    function MaintainClientController(ClientFactory, ClientRecords) {
        var vm = this;
        vm.ClientFactory = ClientFactory;
        vm.ClientFactory.ClientRecords = ClientRecords;//coming from resolve property
        vm.Title = 'Maintain Client';
    }

})();