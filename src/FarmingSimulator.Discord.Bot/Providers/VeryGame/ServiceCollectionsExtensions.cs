namespace FarmingSimulator.Discord.Bot.Providers.VeryGame;

public static class ServiceCollectionsExtensions
{
    public static void AddVeryGameProvider(this IServiceCollection services)
    {
        services.AddOptions<VeryGameOptions>()
            .BindConfiguration(VeryGameOptions.SectionName)
            .ValidateOnStart()
            .ValidateDataAnnotations();
        
        services.AddSingleton<IProvider, VeryGameProvider>();
    }
}