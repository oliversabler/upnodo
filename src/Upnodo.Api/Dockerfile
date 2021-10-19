FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Upnodo.Api/Upnodo.Api.csproj", "Upnodo.Api/"]
COPY ["src/Upnodo.Features.Mood/Upnodo.Features.Mood.Infrastructure/Upnodo.Features.Mood.Infrastructure.csproj", "Upnodo.Features.Mood/Upnodo.Features.Mood.Infrastructure/"]
COPY ["src/Upnodo.Features.Mood/Upnodo.Features.Mood.Application/Upnodo.Features.Mood.Application.csproj", "Upnodo.Features.Mood/Upnodo.Features.Mood.Application/"]
COPY ["src/Upnodo.Features.Mood/Upnodo.Features.Mood.Domain/Upnodo.Features.Mood.Domain.csproj", "Upnodo.Features.Mood/Upnodo.Features.Mood.Domain/"]
COPY ["src/Upnodo.BuildingBlocks/Upnodo.BuildingBlocks.Application/Upnodo.BuildingBlocks.Application.csproj", "Upnodo.BuildingBlocks/Upnodo.BuildingBlocks.Application/"]
COPY ["src/Upnodo.Features.User/Upnodo.Features.User.Application/Upnodo.Features.User.Application.csproj", "Upnodo.Features.User/Upnodo.Features.User.Application/"]
COPY ["src/Upnodo.Features.User/Upnodo.Features.User.Infrastructure/Upnodo.Features.User.Infrastructure.csproj", "Upnodo.Features.User/Upnodo.Features.User.Infrastructure/"]
COPY ["src/Upnodo.Features.User/Upnodo.Features.User.Domain/Upnodo.Features.User.Domain.csproj", "Upnodo.Features.User/Upnodo.Features.User.Domain/"]
RUN dotnet restore "Upnodo.Api/Upnodo.Api.csproj"
COPY . .
WORKDIR "Upnodo.Api"
RUN dotnet build "Upnodo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Upnodo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Upnodo.Api.dll"]