describe('Event List Details: ', function () {
    describe('When clicking on an event', function () {
        var name;

        beforeEach(function () {
            browser.get('http://localhost/SwiftBookingTest.Web/');
            browser.waitForAngular();
        });

        it('Should navigate to the details page', function () {
            var header = element(by.binding('vm.Title'));// browser.driver.findElement(By.id('vmTitle'));
            expect(header.getText()).toMatch("Maintain Client");
        });
        //it('Should update the url', function () {
        //    expect(browser.getCurrentUrl()).toMatch('EventRatings/');
        //});
    });
});
