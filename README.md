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
There will be two existing users on the application.
* Start Without Debugging Cookbook.WebApi.Host (Set Cookbook.WebApi.Host as startup project then press ctrl+F5)
* Start Without Debugging Cookbook.WebApplication (Set Cookbook.WebApplication as startup project then press ctrl+F5)

* username: johnpaul_santos@cookbook.com / password: Johnpaul1!
* username: nicole_reyes@cookbook.com / password: Nicole1!
