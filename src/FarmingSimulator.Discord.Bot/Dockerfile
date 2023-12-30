FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/FarmingSimulator.Discord.Bot/FarmingSimulator.Discord.Bot.csproj", "src/FarmingSimulator.Discord.Bot/"]
RUN dotnet restore "src/FarmingSimulator.Discord.Bot/FarmingSimulator.Discord.Bot.csproj"
COPY . .
WORKDIR "/src/src/FarmingSimulator.Discord.Bot"
RUN dotnet build "FarmingSimulator.Discord.Bot.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_VERSION
ENV BUILD_VERSION ${BUILD_VERSION:-0.0.0}
RUN dotnet publish "FarmingSimulator.Discord.Bot.csproj" -c Release -o /app/publish /p:Version=$BUILD_VERSION /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FarmingSimulator.Discord.Bot.dll"]
