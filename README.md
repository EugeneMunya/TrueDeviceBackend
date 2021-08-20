# TrueDeviceBackend

We need to help people to save their electronic devices unique information using this application so that their devices can be restored very quickly when they are stolen, and also to avoid people buying stolend gadges by for them verifying the device owner using this apllication.

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




