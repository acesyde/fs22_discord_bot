using System.ComponentModel.DataAnnotations;

namespace FarmingSimulator.Discord.Bot.Services.FarmingRestApi;

public class FarmingRestApiOptions
{
    public const string SectionName = "farming";
    
    [Required]
    [Url]
    public string Url { get; set; }
    
    [Range(1,60)]
    public int Timeout { get; set; } = 1;
}