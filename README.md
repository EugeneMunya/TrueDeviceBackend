# TrueDeviceBackend

Application that manages devices unique information.

# Technologies
- .NET5.0
- SQL SERVER
- DOCKER
# Architecture Design
* Docker compose
  * webApi container
  * sqlserver container
# Docker image
[TrueDevice image](https://hub.docker.com/r/munya250/truedevice)

# Testing 
- Pull docker image ```docker pull munya250/truedevice```
- Build container from the image ```docker-compse up -d```
- Visit ```localhost:80/swagger``` in your browser or use postman




