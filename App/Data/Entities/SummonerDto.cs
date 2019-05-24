using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace App.Data.Entities
{
    public class SummonerDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("level")]
        public long Level { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }
        
        [XmlAttribute("aid")]
        public string AccountId { get; set; }

        [XmlElement("match")]
        public List<MatchDto> Matches { get; set; } = new List<MatchDto>();
    }
}