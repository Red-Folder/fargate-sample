FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/out .
HEALTHCHECK --interval=5s --timeout=3s --retries=3 CMD curl -f http://localhost:8100/api/Health || exit 1
ENTRYPOINT ["dotnet", "FargateSampleApp.dll"]