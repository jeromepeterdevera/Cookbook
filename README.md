# Prerequisite
* .NET Core 2.2
* SQL Server 13

# Setup
The application uses two databases, Cookbook and CookbookAuthentication.

To setup Cookbook database.
* execute the update-database command from the package manager console with Cookbook.WebApi.DataAccessLayer as default project and Cookbook.Application as the selected startup project.
* execute the Cookbook.sql file from the Data Seeding folder.

To setup CookbookAuthentication database.
* execute the update-database command from the package manager console with Cookbook.WebApplication as default project and selected startup project.
* execute the CookbookAuthentication.sql file from the Data Seeding folder.

# Testing the application
To test the application, we need to run both Cookbook.WebApi.Host or Cookbook.WebApplication project.

One way to do it is by running either or both of them without the debugger.
* Start Without Debugging Cookbook.WebApi.Host (Set Cookbook.WebApi.Host as startup project then press ctrl+F5)
* Start Without Debugging Cookbook.WebApplication (Set Cookbook.WebApplication as startup project then press ctrl+F5)

You can view the pre-populated data using either of the two users. You can also register a new user.
* username: johnpaul_santos@cookbook.com / password: Johnpaul1!
* username: nicole_reyes@cookbook.com / password: Nicole1!
