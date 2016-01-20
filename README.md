# Swift Code Test Jan 2016

Hi!

This is a C# screening test for developer positions at GetSwift.

The aim is to get a feel for your coding style and how you approach application architecture, as well as to test your knowledge of a few of the core technologies we use with GetSwift.

This should just be a small quick project

We would like to see how you approach the code, using best practices, keeping in mind that the project may have to scale over time.

The API documentation is here: http://app.getswift.co/ApiDocs/Intro

The merchant key to use is: `"3285db46-93d9-4c10-a708-c2795ae7872d"`

We've provided a solution and site for you to start with as well as an home page to fill in. 

*When you're done, submit your changes back to us as a pull request.*

## Requirements

On a single page, please allow the user to enter a series of people's name, address and phone numbers. 
For the purposes of the test there's no requirement to delete or edit the entries, but the code should allow for this to be easy to add later.

These addresses should be stored in a local SQL Server Express database using Entity Framework 6 (code first).

List these addresses on the screen and supply a button that will submit each address individualy to the Swift deliveries API as the "dropoff" address.  Just use any pre-determined address as the "pickup" address.

Display the response from the API call on the screen somewhere.

