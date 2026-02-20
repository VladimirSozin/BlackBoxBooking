FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY BlackBoxBoard.Server.csproj .
RUN dotnet restore BlackBoxBoard.Server.csproj

COPY . .
RUN dotnet publish BlackBoxBoard.Server.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "BlackBoxBoard.Server.dll"]