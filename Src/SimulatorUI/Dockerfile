# ----------------------------------------
# Base image for runtime
# ----------------------------------------
# Use the official Microsoft .NET 9.0 ASP.NET runtime image.
# This image only contains what's needed to RUN a .NET application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Set the working directory inside the container
WORKDIR /app

# Expose the ports the app listen on
EXPOSE 8080
EXPOSE 8081


# ----------------------------------------
# Build image
# ----------------------------------------
# Use the full .NET SDK image, which includes build tools and NuGet.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Allow specifying a build configuration (default = Release)
ARG BUILD_CONFIGURATION=Release

# Set working directory to /src where the project will be copied
WORKDIR /src

# Copy the project file first for better build caching
# This allows Docker to cache NuGet restore layers separately from code changes.
COPY ["SimulatorUI/SimulatorUI.csproj", "SimulatorUI/"]

# Restore NuGet dependencies
RUN dotnet restore "SimulatorUI/SimulatorUI.csproj"

# Copy the remaining project files into the container
COPY . .

# Build the application using the given configuration (Release or Debug)
# The compiled output goes into /app/build
RUN dotnet build "SimulatorUI/SimulatorUI.csproj" -c $BUILD_CONFIGURATION -o /app/build


# ----------------------------------------
# Publish image
# ----------------------------------------
# This stage prepares the app for deployment (optimized output)
FROM build AS publish

# Use the same build configuration as before
ARG BUILD_CONFIGURATION=Release

# Publish the app to /app/publish
# The flag /p:UseAppHost=false prevents creating a platform-specific executable (.exe)
RUN dotnet publish "SimulatorUI/SimulatorUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# ----------------------------------------
# Final runtime image
# ----------------------------------------
# The final image that will actually run in production.
# Based on the lightweight ASP.NET runtime image (no SDK).
FROM base AS final

# Set the working directory for the runtime container
WORKDIR /app

# Copy the published application from the "publish" stage
COPY --from=publish /app/publish .

# Define the entrypoint command
# When the container starts, it will execute:
# dotnet SimulatorUI.dll
ENTRYPOINT ["dotnet", "SimulatorUI.dll"]
