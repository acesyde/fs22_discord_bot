using System.Xml.Serialization;

namespace FarmingSimulator.Discord.Bot.Services.FarmingRestApi.Models;

[XmlRoot(ElementName = "Server")]
public class Server
{
    [XmlElement(ElementName = "Slots")] public Slots Slots { get; set; }
    [XmlAttribute(AttributeName = "game")] public string Game { get; set; }

    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; }

    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "mapName")]
    public string MapName { get; set; }

    [XmlAttribute(AttributeName = "dayTime")]
    public string DayTime { get; set; }

    [XmlAttribute(AttributeName = "mapOverviewFilename")]
    public string MapOverviewFilename { get; set; }

    [XmlAttribute(AttributeName = "mapSize")]
    public string MapSize { get; set; }
}