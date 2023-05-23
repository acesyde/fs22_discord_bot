using FarmingSimulator.Discord.Bot;
using FarmingSimulator.Discord.Bot.Providers.VeryGame;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOptions<DiscordBotOptions>()
            .BindConfiguration(DiscordBotOptions.SectionName)
            .ValidateOnStart()
            .ValidateDataAnnotations();
        
        services.AddHttpClient();
        services.AddHostedService<DiscordBotWorker>();
        services.AddVeryGameProvider();
    })
    .Build();

host.Run();
