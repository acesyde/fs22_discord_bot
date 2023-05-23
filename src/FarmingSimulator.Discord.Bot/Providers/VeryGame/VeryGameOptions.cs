using System.ComponentModel.DataAnnotations;

namespace FarmingSimulator.Discord.Bot.Providers.VeryGame;

public class VeryGameOptions
{
    public const string SectionName = "verygame";
    
    [Required]
    [Url]
    public string Url { get; set; }
    
    [Range(1,60)]
    public int Timeout { get; set; } = 1;
}