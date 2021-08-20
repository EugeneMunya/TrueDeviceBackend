FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /TrueDevice/Api
COPY TrueDevice.csproj .
RUN dotnet restore "TrueDevice.csproj"
COPY .  .
RUN dotnet build "TrueDevice.csproj" -c Release -o /build

FROM build AS publish
RUN dotnet publish "/TrueDevice/Api/TrueDevice.csproj" -c Release -o /publish

FROM base AS final
WORKDIR /
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "TrueDevice.dll"]
