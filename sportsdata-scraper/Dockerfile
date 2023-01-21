FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["sportsdata-scraper.csproj", "./"]
RUN dotnet restore "sportsdata-scraper.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "sportsdata-scraper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sportsdata-scraper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sportsdata-scraper.dll"]
