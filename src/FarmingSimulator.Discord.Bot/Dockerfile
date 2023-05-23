FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base

ARG BUILD_VERSION
ENV BUILD_VERSION ${BUILD_VERSION:-0.0.0}

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FarmingSimulator.Discord.Bot/FarmingSimulator.Discord.Bot.csproj", "src/FarmingSimulator.Discord.Bot/"]
RUN dotnet restore "src/FarmingSimulator.Discord.Bot/FarmingSimulator.Discord.Bot.csproj"
COPY . .
WORKDIR "/src/src/FarmingSimulator.Discord.Bot"
RUN dotnet build "FarmingSimulator.Discord.Bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FarmingSimulator.Discord.Bot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FarmingSimulator.Discord.Bot.dll"]
