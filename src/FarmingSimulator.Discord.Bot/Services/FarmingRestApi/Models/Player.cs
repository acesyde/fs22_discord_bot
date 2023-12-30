using System.Xml.Serialization;

namespace FarmingSimulator.Discord.Bot.Services.FarmingRestApi.Models;

[XmlRoot(ElementName = "Player")]
public class Player
{
    [XmlAttribute(AttributeName = "isAdmin")]
    public bool IsAdmin { get; set; }

    [XmlAttribute(AttributeName = "uptime")]
    public int Uptime { get; set; }

    [XmlText] public string Name { get; set; }
}