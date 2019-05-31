using System.Xml.Serialization;

namespace App.Data.Entities
{
    public class LeagueDto
    {
        [XmlAttribute("q")]
        public string QueueType { get; set; }

        [XmlAttribute("wr")]
        public double Winrate { get; set; }

        [XmlElement("tier")]
        public string Tier { get; set; }

        [XmlElement("rank")]
        public string Rank { get; set; }


    }
}