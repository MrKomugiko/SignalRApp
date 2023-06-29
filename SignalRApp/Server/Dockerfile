#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80	
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SignalRApp/Server/*.csproj", "SignalRApp/Server/"]
COPY ["SignalRApp/Client/*.csproj", "SignalRApp/Client/"]
COPY ["SignalRApp/Shared/*.csproj", "SignalRApp/Shared/"]
COPY ["SignalRApp.Tests/*.csproj", "SignalRApp.Tests/"]
RUN dotnet restore "SignalRApp/Server/SignalRApp.Server.csproj"
COPY . .

# Build the application
WORKDIR "/src/SignalRApp/Server"
RUN dotnet build "SignalRApp.Server.csproj" -c Release -o /app/build

# Run the tests
WORKDIR /app/SignalRApp.Tests
RUN dotnet test --console-logger "console;verbosity=detailed"

FROM build AS publish
RUN dotnet publish "SignalRApp.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalRApp.Server.dll"]