# Project - Bild Studio

## Getting Started
* Clone the repository using the command git clone https://github.com/andrija-mitrovic/BildStudio.git

## Command line
* Install version of the .NET Core SDK 3.1 from this page https://www.microsoft.com/net/download/core
* Update the connection string in appsettings.json
* Next, navigate to D:\BildStudio\src\WebAPI or wherever your folder is.
* In Solution Explorer, ensure src\WebAPI is the startup project.
* Call dotnet run.

##Visual Studio
* Download Visual Studio 2019 (any edition) from https://www.visualstudio.com/downloads/
* Update the connection string in appsettings.json
* Open BildStudio.sln and wait for Visual Studio to restore all Nuget packages.
* Open Package Manager Console Window and make sure that src\Infrastructure is selected as Default project. Then type "Update-Database" and press "Enter". This action will create database schema.
* Build whole solution.
* In Solution Explorer, ensure WebAPI is the startup project and run it.

## Technologies and frameworks used:
* ASP.NET MVC Core 3.1
* SQL Server 2014
* Entity Framework Core 3.1.8
* Angular 8.3.18
* Swashbuckle 6.0.2
