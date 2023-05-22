using FarmingSimulator.Discord.Bot.Providers;

namespace FarmingSimulator.Discord.Bot;

public class DiscordWorker : BackgroundService
{
    private readonly ILogger<DiscordWorker> _logger;
    private readonly IProvider _provider;

    public DiscordWorker(ILogger<DiscordWorker> logger, IProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Discord bot running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
