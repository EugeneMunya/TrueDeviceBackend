# TrueDeviceBackend

Application that manages devices unique infortation.

# Technologyies
- .NET5.0
- SQL SERVER
- DOCKER
# Architecture Design
* Docker compose
  * webapi container
  * sqlserver container
# Docker image
[TrueDevice image](https://hub.docker.com/r/munya250/truedevice)

# Testing 
- Pull docker image ```docker pull munya250/truedevice```
- Build container from the image ```docker-compse up -d```
- Visit ```localhost:80/swagger``` in your browser or user postman




