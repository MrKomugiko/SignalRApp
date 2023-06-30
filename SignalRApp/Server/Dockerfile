#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM "mcr.microsoft.com/dotnet/sdk:6.0" AS build
WORKDIR "/src"
# Copy and restore the Blazor hosted application
COPY "SignalRApp/Server/SignalRApp.Server.csproj" "SignalRApp/Server/"
COPY "SignalRApp/Client/SignalRApp.Client.csproj" "SignalRApp/Client/"
COPY "SignalRApp/Shared/SignalRApp.Shared.csproj" "SignalRApp/Shared/"
RUN dotnet restore "SignalRApp/Server/SignalRApp.Server.csproj"

# Copy and restore the xUnit test project
COPY "./SignalRApp.Tests/SignalRApp.Tests.csproj" "SignalRApp.Tests/"
RUN dotnet restore "./SignalRApp.Tests/SignalRApp.Tests.csproj"

# Copy the remaining project files
COPY . .

# Build the Blazor hosted application and publish it
WORKDIR "/src/SignalRApp/Server"
RUN dotnet build "SignalRApp.Server.csproj" -c Release -o "/app/build"

FROM build AS unit-tests
WORKDIR "/src/SignalRApp.Tests"
RUN echo "Running unit tests..."
RUN dotnet test "SignalRApp.Tests.csproj" --logger "console;verbosity=detailed"
RUN echo "Unit tests succesed."

FROM unit-tests AS publish
WORKDIR "/src/SignalRApp/Server"
RUN dotnet publish "SignalRApp.Server.csproj" -c Release -o "/app/publish"

# Runtime stage
FROM "mcr.microsoft.com/dotnet/aspnet:6.0" AS runtime
WORKDIR /app
COPY --from=publish "/app/publish" .
ENTRYPOINT ["dotnet", "SignalRApp.Server.dll"]