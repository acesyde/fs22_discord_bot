using System.Xml.Serialization;
using FarmingSimulator.Discord.Bot.Domain.Services;
using FarmingSimulator.Discord.Bot.Models;
using FarmingSimulator.Discord.Bot.Services.FarmingRestApi.Models;
using Microsoft.Extensions.Options;

namespace FarmingSimulator.Discord.Bot.Services.FarmingRestApi;

public class FarmingRestApiPlayerService(
    IOptions<FarmingRestApiOptions> options,
    ILogger<FarmingRestApiPlayerService> logger,
    IHttpClientFactory httpClientFactory)
    : IPlayerService
{
    private readonly FarmingRestApiOptions _options = options.Value;

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
            return (Server) serializer.Deserialize(stream)!;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unable to parse the VeryGame result");
            return null;
        }
    }

    private async Task<Stream?> GetVeryGameContentAsync()
    {
        logger.LogDebug("Call VeryGame api");

        var client = httpClientFactory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(_options.Timeout);
        try
        {
            var response = await client.GetAsync(_options.Url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unable to contact VeryGame Url");
            return null;
        }
    }
}