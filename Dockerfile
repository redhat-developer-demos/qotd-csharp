FROM registry.access.redhat.com/ubi8/dotnet-31:3.1
USER 1001
RUN mkdir qotd-csharp
WORKDIR qotd-csharp
ADD . .

RUN export TMPDIR=/tmp/NuGetScratch
RUN mkdir -p ${TMPDIR}
RUN dotnet publish -c Release

EXPOSE 10000
CMD ["dotnet", "run", "/bin/Release/netcoreapp3.0/linux-x64/publish/qotd-csharp.dll"]