# Prerequisite
* .NET Core 2.2
* SQL Server 13

# Setup
The application uses two databases, Cookbook and CookbookAuthentication.

To setup the databases do the following.
* Open the Cookbook.sln in Visual Studio, go to Package Manager Console set Cookbook.WebApi.DataAccessLayer as the Default Project and Cookbook.WebApi.Host as the startup project then run update-database from the Package Manager Console.
* then, change the default project in Package Manager Console and the StartUp Project to Cookbook.WebApplication and run update-database again.
* execute the Cookbook.sql file from the Data Seeding folder.
* execute the CookbookAuthentication.sql file from the Data Seeding folder.

# Testing the application
To test the application, we need to run both Cookbook.WebApi.Host and Cookbook.WebApplication project.

One way to do that is by running either or both of them without the debugger attached.
* Start Without Debugging Cookbook.WebApi.Host (Set Cookbook.WebApi.Host as startup project then press ctrl+F5)
* Start Without Debugging Cookbook.WebApplication (Set Cookbook.WebApplication as startup project then press ctrl+F5)

You can view the pre-populated data using either of the two users. You can also register a new user.
* username: johnpaul_santos@cookbook.com / password: Johnpaul1!
* username: nicole_reyes@cookbook.com / password: Nicole1!
