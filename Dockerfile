FROM registry.access.redhat.com/ubi8/dotnet-31:3.1
USER 1001
RUN mkdir qotd-csharp
WORKDIR qotd-csharp
ADD . .
RUN dotnet restore
RUN dotnet publish -c Release 
EXPOSE 10000
CMD ["dotnet", "run", "/bin/Release/netcoreapp3.1/publish/qotd-csharp.dll"]