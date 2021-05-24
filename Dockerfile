# Fetch .NET 5
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy and restore
COPY . ./
RUN dotnet restore

# Publish
RUN dotnet publish -c release -o out --no-restore

# Create image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out/ ./
ENTRYPOINT [ "dotnet", "Upnodo.Api.dll" ]