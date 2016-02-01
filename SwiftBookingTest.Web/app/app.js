angular.module('swiftApp', [])
        .factory('repo', function ($http) {
            var getUrl = function (url) {
                return window.g_baseUrl + url;
            };
            return {
                getPeople: function () {
                    var req = $http.get(getUrl('api/People'));
                    return req;
                },
                addPeople: function (person) {
                    var req = $http.put(getUrl('api/People'), person);
                    return req;
                },
                book: function (person) {
                    var req = $http.post(getUrl('api/Delivery/Book'), person);
                    return req;
                }
            };
        })