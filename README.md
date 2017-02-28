# UCAS Technical Assignment

## Requirements
Create a web application with following features:
1. List page to show list of events (title, location and date) with most recent event at the top
1. On clicking the event title, user should be navigated to event details e.g. description, location and time
For UI, you can use either MVC or any SPA framework - Angular preferred. You can use server side in memory data store to keep the application simple.
 
Any additional features like sorting, pagination will be a bonus.

## Running Locally
Clone the respository and then perform the following steps to set up the Event Query API:

1. Open the Mcet.Ucas.Event.Service Query API solution in Visual Studio and build it
1. Run the unit / acceptance Tests - the acceptance tests will fail as the API is not running yet 
1. Invoke the PowerShell script in the root of the repsitory 'initialize-iiswebsite.ps1' to create an IIS Web Site and host entry which can be used to access the API - http://http://event-queryapi.ucas.local/
1. Navigate to the following URLs to confirm the API is running:
   - http://event-queryapi.ucas.local/events?pagenumber=1&pageSize=10
   - http://event-queryapi.ucas.local/events/a682adc7-1163-4a32-a867-3362756499f7/
1. Re-run the acceptance tests and confirm they all pass.

Finally perform the following steps to set up the Event Viewer UI:

1. [Install Node.js](https://docs.npmjs.com/getting-started/installing-node) and update the npm.
1. From a command prompt / shell navigate to the Mcet.Ucas.Event.UI directory
1. Launch the site by executing these terminal commands  
```
npm install
npm start
```