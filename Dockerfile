FROM registry.access.redhat.com/ubi8/dotnet-70 AS base

WORKDIR /opt/app-root/app
# EXPOSE 80
# EXPOSE 443
EXPOSE 5000

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
ENTRYPOINT ["dotnet", "qotd-csharp.dll"]
