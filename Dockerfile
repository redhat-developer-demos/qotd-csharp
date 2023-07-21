#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM registry.access.redhat.com/ubi8/dotnet-70 AS base

WORKDIR /opt/app-root/app
#EXPOSE 80
#EXPOSE 443
EXPOSE 5000

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
FROM registry.access.redhat.com/ubi8/dotnet-70 AS build
WORKDIR /opt/app-root/src
COPY ["qotd-csharp.csproj", "."]
RUN dotnet restore "./qotd-csharp.csproj"
COPY . .
WORKDIR "/opt/app-root/src/."
RUN dotnet build "qotd-csharp.csproj" -c Release -o /opt/app-root/app/build

FROM build AS publish
RUN dotnet publish "qotd-csharp.csproj" -c Release -o /opt/app-root/app/publish

FROM base AS final
WORKDIR /opt/app-root/app
COPY --from=publish /opt/app-root/app/publish .
ENV ASPNETCORE_URLS="http://0.0.0.0:5000"
ENTRYPOINT ["dotnet", "qotd-csharp.dll"]