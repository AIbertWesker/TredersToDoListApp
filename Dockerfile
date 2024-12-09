# Base stage for running
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 6966

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TredersToDoListApp/TredersToDoListApp.csproj", "TredersToDoListApp/"]
COPY ["TredersToDoListApp.API/TredersToDoListApp.API.csproj", "TredersToDoListApp.API/"]
COPY ["TredersToDoListApp.Application/TredersToDoListApp.Application.csproj", "TredersToDoListApp.Application/"]
COPY ["TredersToDoListApp.Domain/TredersToDoListApp.Domain.csproj", "TredersToDoListApp.Domain/"]
COPY ["TredersToDoListApp.Infrastructure/TredersToDoListApp.Infrastructure.csproj", "TredersToDoListApp.Infrastructure/"]
RUN dotnet restore "./TredersToDoListApp/TredersToDoListApp.csproj"
COPY . .
WORKDIR "/src/TredersToDoListApp"
RUN dotnet build "./TredersToDoListApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TredersToDoListApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:6966
ENTRYPOINT ["dotnet", "TredersToDoListApp.dll"]
