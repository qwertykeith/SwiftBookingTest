/// <reference path="../Scripts/_references.js" />



(function () {
    describe("", function () {
        var scope, controller, ClientFactoryMock, window;
        var ClientRecords = {}
        beforeEach(function () {

            module("mainModule");
            inject(function ($rootScope, $controller, ClientFactory) {
                scope = $rootScope.$new();
                ClientFactoryMock = sinon.stub(ClientFactory);
                controller = $controller('MaintainClientController', { ClientRecords: ClientRecords });
            });
        });

        it("MaintainClientController Init", function () {
            expect(controller).toBeDefined();
            expect(controller.Title).toBe("Maintain Client");
        });

    });
}());