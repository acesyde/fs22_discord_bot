using Discord;
using Discord.Rest;
using Discord.WebSocket;
using FarmingSimulator.Discord.Bot.Providers;
using Microsoft.Extensions.Options;

namespace FarmingSimulator.Discord.Bot;

public class DiscordBotWorker : IHostedService
{
    private readonly ILogger<DiscordBotWorker> _logger;
    private readonly DiscordBotOptions _options;
    private readonly IProvider _provider;
    private readonly DiscordSocketClient _discordSocketClient;

    public DiscordBotWorker(ILogger<DiscordBotWorker> logger, IOptions<DiscordBotOptions> options, IProvider provider)
    {
        _logger = logger;
        _options = options.Value;
        _provider = provider;
        _discordSocketClient = new DiscordSocketClient();
        _discordSocketClient.Ready += DiscordSocketClientOnReady;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting discord bot");
        await _discordSocketClient.LoginAsync(TokenType.Bot, _options.Token);
        await _discordSocketClient.StartAsync();
    }

    private async Task DiscordSocketClientOnReady()
    {
        _logger.LogInformation("Discord bot is ready");
        await _discordSocketClient.SetGameAsync("Farming Simulator 22");
        await ExecuteAsync();
    }

    private async Task ExecuteAsync()
    {
        while (true)
        {
            _logger.LogInformation("Update information");

            try
            {
                // var players = await _provider.GetPlayersAsync();

                await _discordSocketClient.SetGameAsync("FS22 : 0/0");

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while updating information");
            }
            
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping discord bot");
        return _discordSocketClient.StopAsync();
    }
}