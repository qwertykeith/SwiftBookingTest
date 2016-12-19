(function () {
    'use strict';

    /*
     * @Client factory is the representation of client controller
     */
    angular.module("commonModule").factory("APIFactory", APIFactory);

    APIFactory.$inject = ["$http"];
    function APIFactory($http) {

        var service = {
            Post: Post,
            Get: Get,
            Put: Put
        }

        /*
         * @description Makes post call
         * @param {apiUrl} Url of API
         * @param {params} Model to pass
         */
        function Post(apiUrl, model) {
            // Mmake a call to server with the parameters passed
            // from the controller.
            var xhr = {};
            xhr = $http({
                method: 'POST',
                url: apiUrl,
                data: model || null,
                //headers: config || null, // Optional headers
            });
            return xhr
        }

        /*
         * @description Makes get call
         * @param {apiUrl} Url of API
         * @param {params} Params to pass
         */
        function Get(apiUrl, params) {
            // Make a call to server with the parameters passed
            // from the controller.
            var xhr = $http({
                method: 'GET',
                url: apiUrl,
                params: params || null,
                //headers: config || null, // Optional headers
            });

            return xhr;
        }

        function Put(apiUrl, model) {
            var xhr = $http({
                method: 'PUT',
                url: apiUrl,
                data: model || null,
                //headers: config || null, // Optional headers
            });

            return xhr;
        }

        return service;

    }
})();