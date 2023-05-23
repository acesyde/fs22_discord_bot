using System.Xml.Serialization;

namespace FarmingSimulator.Discord.Bot.Providers.VeryGame.Models;

[XmlRoot(ElementName="Slots")]
public class Slots {
    [XmlElement(ElementName="Player")]
    public List<Player> Player { get; set; }
    [XmlAttribute(AttributeName="capacity")]
    public int Capacity { get; set; }
    [XmlAttribute(AttributeName="numUsed")]
    public int NumUsed { get; set; }
}