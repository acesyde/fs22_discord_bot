using FarmingSimulator.Discord.Bot.Domain.Services;

namespace FarmingSimulator.Discord.Bot.Services.FarmingRestApi;

public static class ServiceCollectionsExtensions
{
    public static void AddVeryGameProvider(this IServiceCollection services)
    {
        services.AddOptions<FarmingRestApiOptions>()
            .BindConfiguration(FarmingRestApiOptions.SectionName)
            .ValidateOnStart()
            .ValidateDataAnnotations();
        
        services.AddSingleton<IPlayerService, FarmingRestApiPlayerService>();
    }
}