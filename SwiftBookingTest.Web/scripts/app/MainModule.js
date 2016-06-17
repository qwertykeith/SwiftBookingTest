(function () {
    "use strict";
    /*
     * @description Main app module
     */
    angular.module("mainModule", ["ui.router", "commonModule", "ngNotify"]);

    /*
     * @description Configuration for main app module
     */
    angular.module("mainModule").config(config);
    config.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider"];
    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        var clientBaseUrl = "scripts/app/client/templates/";
        // For any unmatched url, redirect to /maintain client
        $urlRouterProvider.otherwise("/MaintainClient");
        //
        // Now set up the states
        $stateProvider
          .state("MaintainClient", {
              url: "/MaintainClient",
              templateUrl: clientBaseUrl + "MaintainClient.html",
              controller: "MaintainClientController",
              controllerAs: "vm",
              resolve: {
                  ClientRecords: function ($q, $http, ClientFactory) {
                      var deferred = $q.defer();
                      $http.get(ClientFactory.apiUrl).then(function (response) {
                          deferred.resolve(response.data);
                      });
                      return deferred.promise;
                  }
              }
          });


        $locationProvider.html5Mode(true);
    }

}());