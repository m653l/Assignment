# Assignment
## Table of Contents

- [Architecture Overview](#architecture-overview)
- [More info about the project](#more-info-about-the-project)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application-locally)
- [Setting up the CI/CD pipeline](#setting-up-the-cicd-pipeline)
- [Deploying in Azure](#deploying-in-azure)
- [Conclusion](#conclusion)
- [Comments](#comments)

## Architecture Overview
This project follows the principles of Clean Architecture and Domain-Driven Design. The codebase is organized into layers, each with a specific responsibility:

- Presentation Layer: Contains the minimal APIs and presentation logic.
- Application Layer: Implements use cases and coordinates the application's behavior.
- Domain Layer: Contains the core business logic and entities.
- Infrastructure Layer: Deals with data access, external services, and other infrastructure concerns.

Project also incorporates: IUnitOfWork and CQRS patterns.

## More info about the project
- For data access, I am using a hybrid solution of Dapper and EF Core.
- The used database is PostgreSQL.
- Logging is handled by Serilog with sinks to Console and Seq (only locally).

## Prerequisites
Ensure that the following software is installed on your machine:
- .NET SDK 8
- Docker

## Installation
Navigate to the project directory and run the following command to restore the dependencies:
``` dotnet restore ```

## Running the Application Locally
The API will be accessible at [http://localhost:5000/](http://localhost:5000) by default. Run the following command to start the API:
``` docker compose up ```
Or run the docker-compose.yml file in Visual Studio 2022 / JetBrains Rider

## Setting up the CI/CD pipeline
The main workflow will run automatically on push or merge to the master branch.

In order to configure the CI/CD pipeline in fork, it is required to:
  - Add the AZURE_PUBLISH_PROFILE (the value can be downloaded from your Azure App Service) to your secrets in the GitHub repository secrets.
  - In main.yml set name of your Azure App Service
    
The pipeline will:
  - Setup dotnet in version '8.0.x'
  - Restore nuget packages for solution
  - Build the project in Release configuration
  - Publish it to ./publish path
  - Deploy the changes to the Azure App Service

## Deploying in Azure
What is required:
  - App Service Web App configured with Code Publishing Model for .NET 8 (LTS)
  - The Azure Database for PostgreSQL server
Configuration:
  - Allow the Basic Auth in the App Service
  - Download the publishing profile and put it in your AZURE_PUBLISH_PROFILE secret
  - The Azure Database needs to allow traffic from the API (Settings -> Networking -> Add Firewall Rule)
  - Create an assignment database in Azure Database
    
Setup:
  - Place the connection string from the Azure Database in appsettings.json

## Conclusion
That should be it! After pushing to the master branch, the pipeline will start, build the project and deploy it to Azure Web App.

## Comments
Currently, the database connection string is stored in appsettings.json, it is only for demonstration purposes.
The project does not include any tests, like in a normal production environment.
