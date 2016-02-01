angular.module('swiftApp')
    .controller('DeliveryController', function ($scope, $http, repo) {
        $scope.p = {};
        $scope.people = [];
        $scope.error = false;
        $scope.response = 'Results from the API call go here!';
        repo.getPeople().success(function (result) {
            $scope.people = result;
        });
        $scope.book = function (dropoff) {
            var booking = {
                pickup: {
                    Name: 'Jason',
                    Phone: '04000000',
                    Address: 'Melbourne'
                },
                dropoff: dropoff
            };
            repo.book(booking)
                .success(function (result) {
                    $scope.response = result;
                    $scope.error = false;
                })
                .error(function (data, status) {
                    $scope.response = data;
                    $scope.error = true;
                });
        };
        $scope.addPeople = function () {
        	if (!$scope.myForm.$valid) return;
            var p = angular.copy($scope.p);
            var old = $scope.people.find(function (pi) {
                return pi.Address == p.Address;
            });
            if (old) {
                old.Name = p.Name;
                old.Phone = p.Phone;
            }
            else {
                repo.addPeople(p)
                    .success(function (result) {
                        $scope.people.push(p);
                    })
                    .error(function (data, status) {
                        alert(data);
                    });                
            }
        };
    });