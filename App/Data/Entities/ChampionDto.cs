using System.Xml.Serialization;

namespace App.Data.Entities
{
    public class ChampionDto
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("k")]
        public string Key { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("img")]
        public string Image { get; set; }

    }
}