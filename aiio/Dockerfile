# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything inside aiio/ directory into container
COPY . .

# Restore from solution
RUN dotnet restore aiio.sln

# Publish the main app project
RUN dotnet publish aiio.app/aiio.app.csproj -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Optional: expose app port
EXPOSE 80

ENTRYPOINT ["dotnet", "aiio.app.dll"]
