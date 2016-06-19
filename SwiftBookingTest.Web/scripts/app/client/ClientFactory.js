(function () {
    'use strict';

    /*
     * @Client factory is the representation of client controller
     */
    angular.module("mainModule").factory("ClientFactory", ClientFactory);

    ClientFactory.$inject = ["APIFactory", "$timeout", "$q", "ngNotify"];
    function ClientFactory(APIFactory, $timeout, $q, ngNotify) {

        var service = {
            apiUrl: "api/Clients",
            formClientMaintenance: {},
            Client: {
                "Name": "", "Address": "", ClientPhones: [
                ]
            },
            ClientCopy: {
                Name: "", Address: "", ClientPhones: [
                ]
            },
            ClientRecords: [],
            ClientPhones: "",
            SaveClient: SaveClient,
            Update: Update,
            SendDelivery: SendDelivery,
            GetByInstructor: GetByInstructor,
            IsBusy: false,
            PhoneNumber: { "Number": "", Id: null },
            AddPhoneNumber: AddPhoneNumber,
            SelectedClient: null,
            SelectClient: SelectClient
        }

        /*
         * @description Save client and gets the updated result
         */
        function SaveClient() {
            service.IsBusy = true;
            var ClientPhones = service.ClientPhones.replace(/[\s,]+/g, ',').split(",");
            angular.forEach(ClientPhones, function (phone) {
                service.Client.ClientPhones.push({ "ClientRecord": null, "PhoneNumber": { Number: phone }, "PhoneNumberId": -1, "ClientRecordId": -1 });
            });

            APIFactory.Post(service.apiUrl + "/Post", service.Client).then(function (response) {
                service.ClientRecords.push(response.data);
            }, function (error) {
                Notification.error(error.data);
            }).finally(function () {
                //just for demo
                ResetForm();
            });
        }


        function GetByInstructor() {
            $http.get(service.apiUrl + "/GetByInstructor?Id=1").then(function (response) {
                console.log(response.data);
            }, function (error) {
                console.log(error);
            });
        }

        /*
         * Reset the form data to original state
         */
        function ResetForm() {
            service.IsBusy = false;
            service.Client = angular.copy(service.ClientCopy);
            service.ClientPhones = "";
            service.formClientMaintenance.$setPristine();
        }
        /*
         * @description Calls the API to send the delivery
         */
        function SendDelivery(clientRecord) {

            APIFactory.Post(service.apiUrl + "/SendDelivery", clientRecord).then(function (response) {
                if (response.data.code !== "InvalidDropoffAddress") {
                    ngNotify.set("Your request has been received. It will be picked up from " + response.data.delivery.pickupLocation.address, {
                        type: 'success',
                        duration: 6000,
                        position: 'top',
                        sticky: true,

                    });

                }
                else {
                    ngNotify.set(response.data.message, {
                        type: 'warn',
                        duration: 2000,
                        position: 'top',
                        theme: "prime"
                    });
                }
            }, function (error) {
                ngNotify.set(error.data.ExceptionMessage, {
                    type: 'warn',
                    duration: 2000,
                    position: 'top',
                    theme: "prime"
                });
            });
        };

        /*
         * @description Update client record
         */
        function Update(clientRecord) {
            APIFactory.Put(service.apiUrl + "?Id=" + service.SelectedClient.Id,
            service.SelectedClient).then(function (response) {
                clientRecord = response.data;
            }, function (error) {
                ngNotify.set(error.data.ExceptionMessage, {
                    type: 'error',
                    sticky: true,
                    position: 'top',
                    theme: "prime"
                });
            });
        };

        function AddPhoneNumber() {
            service.SelectedClient.ClientPhones.push({
                "ClientRecord": null,
                "PhoneNumber": { Number: service.PhoneNumber.Number },
                "PhoneNumberId": -1,
                "ClientRecordId": -1
            });
        };

        function SelectClient(clientRecord) {
            service.SelectedClient = clientRecord;
        };

        return service;

    }
})();