using System.Xml.Serialization;

namespace App.Data.Entities
{
    public class ParticipantDto
    {
        [XmlAttribute("name")]
        public string SummonerName { get; set; }

        [XmlAttribute("cid")]
        public int ChampionId { get; set; }

        [XmlAttribute("tid")]
        public int TeamId { get; set; }
    }
}