(function () {
    'use strict';
    /*
     * @description Main app module
     */
    angular.module('mainModule', ['ui.router', 'commonModule', 'ngNotify']);

    /*
     * @description Configuration for main app module
     */
    angular.module('mainModule').config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];
    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        var clientBaseUrl = 'scripts/app/client/Template/';
        // For any unmatched url, redirect to /maintain client
        $urlRouterProvider.otherwise('/');
        //
        // Now set up the states
        $stateProvider
          .state('MaintainClient', {
              url: '/',
              templateUrl: 'client/template/MaintainClient.cshtml',
              controller: 'MaintainClientController',
              controllerAs: 'vm',
              resolve: {
                  ClientRecords: function ($q, $http, ClientFactory) {
                      var deferred = $q.defer();
                      //$http.get(ClientFactory.apiUrl).then(function (response) {
                      //    deferred.resolve(response.data);
                      //});
                      $http.get("ClientRecords/Index").then(function (response) {
                          deferred.resolve(response.data);
                      });
                      return deferred.promise;
                  }
              }
          })
        .state('Client', {
            url: '/Client/:id',
            templateUrl: 'client/template/GetClient.cshtml',
            controller: 'GetClientController',
            controllerAs: 'vm',
            resolve: {
                Client: function ($q, ClientFactory, $stateParams) {
                    var deferred = $q.defer();
                    ClientFactory.getClient($stateParams.id).then(function (response) {
                        deferred.resolve(response.data);
                    });
                    return deferred.promise;
                }
            }
        });


        //$locationProvider.html5Mode(true);
    }

}());