FROM mcr.microsoft.com/dotnet/core/sdk as publish
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out BugTracker.Service/BugTracker.Service.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /dist
COPY --from=publish /app/out .
CMD [ "dotnet", "BugTracker.Service.dll" ]