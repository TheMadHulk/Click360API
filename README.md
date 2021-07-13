# Click 360 API

*Due to Identity Server requiring SSL support on host names other then localhost you can no longer use IIS Express*

## Development Environment Setup

*You only need to do these instructions once, if you have problems see engineers*

1. Create a hostfile entry for test-360selfdrive-api.com pointing to your machine's IP address it cannot be 127.0.0.1 cause of SSL
2. You will need to install the SSL cert
3. Open IIS Manager
	- Create an AppPool for the Click360 API
		- Name it local-api
		- Set .NET to v4.0.*
		- Set Pipeline mode to Integrated
		- Click ok
		- Right Click the new AppPool and choose Advanced Settings
		- Change Identity to the user you sign on to your machine as use .\username if your machine is not attached to a domain. You will also need to enter your password twice.
		- Change Idle Time-Out to 120 minutes
		- Click Ok
	- Add a new site for the Click360 API
		- Set Name to test-360selfdrive-api.com
		- Choose the app pool you created already, local-api
		- Set physical path to {SolutionRoot}\Click360.API
		- Set Binding Type to HTTPS
		- Set Binding Hostname to test-360selfdrive-api.com
		- Choose SSL Certificate
		- Click Ok
4. Open Visual Studio 2015 as Administrator
	- Open the Click360 solution
	- Right click Click360.API and choose properties
		- Change to the Web section
		- Change Start Action to Don't open a page
		- Uncheck Apply server settings to all users
		- Change the DDL to Local IIS
		- Set project URL to https://test-360selfdrive-api.com
		- Click the save button in the tool bar
