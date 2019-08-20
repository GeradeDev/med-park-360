# med-park-360
Sample reference microservice and container based application. Cross-platform on Linux and Windows Docker Containers, powered by .NET Core 2.2 and Docker engine.

## Services / Status

| Basket API   | Catalog API | Identity API | Order API | 
| ------------- | ------------- | ------------- | ------------- |
| [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master) | [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master)| [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master)| [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master)| 

| Customer API   | Medical Parctice API | Payment API | Booking API | 
| ------------- | --------------------- | ------------- | ------------- |
| [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master) | [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master)| [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master)| [![Build Status](https://dev.azure.com/GeradeDev/MedPark-360/_apis/build/status/Med-Park-360-Dev?branchName=master)](https://dev.azure.com/GeradeDev/MedPark-360/_build/latest?definitionId=7&branchName=master)| 

## Motivation

- Developing independently deployable and scalable micro-services
- Developing maintainable aspnet-core MVC application to interact with.
- Developing maintainable and testable Mobile-App using Xamarin.Forms
- Using an event driven approach for eventual consistency between services
- Configuring CI/CD pipelines
- Using Docker
- Writing clean, maintainable and fully testable code
- Using SOLID principles
- Using Design Patterns

# Microservices based cloud native app using Docker, Kubernetes and .NET Core
Sample cloud native e-commerce application which uses microservices based architecture running on .NET Core and Docker, which can be orchestrated by either Docker Swarm, Kubernetes or Service Fabric. It can be configured to use only local resources (RabbitMQ, SQL Server, Redis) or it can use cloud resources. If using cloud resources, it is using Azure App Configuration and Key Vault to store sensitive information like connection strings. You can run it locally on Docker, Docker Swarm, or Kubernetes, or you can deploy it to Azure and run on either Kubernetes or Service Fabric.

## What does it do?
Med Park 360 is a one stop portal where people can book appointments with medical specialists nearby. Med Park 360 also provides a service to order your prescribed medication right from the portal. The system is composed of 8 microservices, an API gateway, customer portal MVC web application and a client Xamarin application (Coming soon).

## How to run it?
You can launch the sample locally on Docker, on a local Docker Swarm, on local Kubernetes.

### Local Docker environment
RabbitMq is used as the message broker between the services. Can start it by executing the rabbitMq infra docker command as follows in the scripts folder:
```
docker-compose build
docker-compose up
```

Since the backend is composed of multiple microservices, we can orchestrate the entire backend system. The easiest is to use docker compose. First build it, and then run it.

```
docker-compose build
docker-compose up
```

These services also require SQL Server to work. Please ensure that your local SQL server can be access via TCP. Follow this guide if you are not sure. [TO DO: SQL SERVER INSIDE A DOCKER CONTAINER]

Once you have all the services running in docker you can go ahead and cd to the web project and run the web project. This will start up the MVC web project:
```
dotnet run
```
