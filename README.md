# TrueDeviceBackend

We need to help people to use this applicationton in order to manage unique information of heir electronic devices so that their devices can be restored very quickly when they are stolen, we also need to avoid people for buying stolend gadges, where they will use this application to verify the device owner before they pay.

# Technologyies
-.NET5.0
-SQL SERVER
-DOCKER
# Architecture Design
* Docker compose
  * webapi container
  * sqlserver container
# Docker image
[TrueDevice image](https://hub.docker.com/repository/docker/munya250/truedevice)

# Testing 
- Pull docker image ```docker pull munya250/truedevice:latest```
- Build container from the image ```docker-compse up -d```
- Visit ```localhost:80/swagger``` in your browser




