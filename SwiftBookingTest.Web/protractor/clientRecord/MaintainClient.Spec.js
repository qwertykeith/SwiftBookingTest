describe('Event List Details: ', function () {
    describe('When clicking on an event', function () {
        var name;

        beforeEach(function () {
            
            //firstElement.getText().then(function (text) {
            //    name = text;
            //});

            //firstElement.click();
            
        });

        it('Should navigate to the details page', function () {
            browser.ignoreSynchronization = true;
            browser.get('http://localhost/SwiftBookingTest.Web/');
            browser.waitForAngular();
            browser.sleep(5000);
            var header = element(by.binding('vm.Title'));// browser.driver.findElement(By.id('vmTitle'));
            expect(header.getText()).toMatch("Maintain Client");

            //var header = element(by.binding('name'));

            //expect(header.getText()).toMatch('Jazz On The Green');
        });

        //it('Should update the url', function () {
        //    expect(browser.getCurrentUrl()).toMatch('EventRatings/');
        //});
    });
});
