# Swift Code Test Jan 2016

Hi!

This test is to help us filter candidates for the C# Developer position at GetSwift.

The aim is to get a feel for your coding style and how you approach application architecture, as well as to test your knowledge of a few of the core technologies we use with GetSwift.

This should just be a small quick project, we would like to see how you would approach the code using best practices with the view that the project might become much larger over time.

Our website is http://www.getswift.co/

The merchant key to use is: "3285db46-93d9-4c10-a708-c2795ae7872d"

The rest of it should be easy to work out, but please let us know if you have any questions, or if something is confusing

When you're done, submit your changes back to us as a pull request

## Requirements

On a single page, please allow the user to enter a series of addresses. 
For the purposes of the test there's no requirement to delete or edit the entries, but the code should allow for this to be easy to add later.

These addresses should be stored in a local SQL Server Express database using entites framework (code first).

List these addresses on the screen and supply a button that will submit each address individualy to the Swift deliveries API as the "dropoff" address.  Just use any pre-determined address as the "pickup" address.

Display the response from the API call on the screen somewhere.

