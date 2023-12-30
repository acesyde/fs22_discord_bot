using FarmingSimulator.Discord.Bot.Models;

namespace FarmingSimulator.Discord.Bot.Domain.Services;

public interface IPlayerService
{
    public Task<GetPlayersCount?> GetPlayersAsync();
}