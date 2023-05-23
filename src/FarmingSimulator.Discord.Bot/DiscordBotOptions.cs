using System.ComponentModel.DataAnnotations;

namespace FarmingSimulator.Discord.Bot;

public class DiscordBotOptions
{
    public const string SectionName = "DiscordBot";
    
    [Required]
    public string Token { get; set; }
}