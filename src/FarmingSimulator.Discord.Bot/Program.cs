using FarmingSimulator.Discord.Bot;
using FarmingSimulator.Discord.Bot.Providers.VeryGame;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddHostedService<DiscordWorker>();
        services.AddVeryGameProvider();
    })
    .Build();

host.Run();
