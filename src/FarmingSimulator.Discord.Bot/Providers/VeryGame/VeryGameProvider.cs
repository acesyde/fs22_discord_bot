using System.Xml.Serialization;
using FarmingSimulator.Discord.Bot.Providers.Models;
using FarmingSimulator.Discord.Bot.Providers.VeryGame.Models;
using Microsoft.Extensions.Options;
using Player = FarmingSimulator.Discord.Bot.Providers.Models.Player;

namespace FarmingSimulator.Discord.Bot.Providers.VeryGame;

public class VeryGameProvider : IProvider
{
    private readonly ILogger<VeryGameProvider> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly VeryGameOptions _options;

    public VeryGameProvider(IOptions<VeryGameOptions> options, ILogger<VeryGameProvider> logger,
        IHttpClientFactory httpClientFactory)
    {
        _options = options.Value;
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetPlayersCount?> GetPlayersAsync()
    {
        var stream = await GetVeryGameContentAsync();
        if (stream == null)
            return null;

        var server = ParseContent(stream);

        if (server == null)
            return null;

        return new GetPlayersCount(server.Slots.Capacity, server.Slots.NumUsed);
    }

    private Server? ParseContent(Stream stream)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Server));
            return (Server) serializer.Deserialize(stream);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unable to parse the VeryGame result");
            return null;
        }
    }

    private async Task<Stream?> GetVeryGameContentAsync()
    {
        _logger.LogDebug("Call VeryGame api");

        var client = _httpClientFactory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(_options.Timeout);
        try
        {
            var response = await client.GetAsync(_options.Url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unable to contact VeryGame Url");
            return null;
        }
    }
}