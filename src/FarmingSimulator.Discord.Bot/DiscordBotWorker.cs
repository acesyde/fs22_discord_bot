using Discord;
using Discord.Commands;
using Discord.WebSocket;
using FarmingSimulator.Discord.Bot.Domain.Services;
using Microsoft.Extensions.Options;

namespace FarmingSimulator.Discord.Bot;

public class DiscordBotWorker : IHostedService
{
    private readonly ILogger<DiscordBotWorker> _logger;
    private readonly DiscordBotOptions _options;
    private readonly IPlayerService _playerService;
    private readonly DiscordSocketClient _discordSocketClient;

    public DiscordBotWorker(ILogger<DiscordBotWorker> logger, IOptions<DiscordBotOptions> options, IPlayerService playerService)
    {
        _logger = logger;
        _options = options.Value;
        _playerService = playerService;
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
        await UpdateBotActivityAsync();
    }

    private async Task UpdateBotActivityAsync()
    {
        while (true)
        {
            _logger.LogInformation("Update information");

            try
            {
                var playersCount = await _playerService.GetPlayersAsync();
                if (playersCount != null)
                {
                    await _discordSocketClient.SetGameAsync(
                        $"FS22 : {playersCount.SlotsUsed}/{playersCount.SlotsAvailable}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while updating information");
            }

            await Task.Delay(TimeSpan.FromSeconds(30));
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping discord bot");
        return _discordSocketClient.StopAsync();
    }
}