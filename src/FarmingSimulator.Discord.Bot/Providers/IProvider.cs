using FarmingSimulator.Discord.Bot.Providers.Models;

namespace FarmingSimulator.Discord.Bot.Providers;

public interface IProvider
{
    public Task<IReadOnlyList<Player>> GetPlayersAsync();
}