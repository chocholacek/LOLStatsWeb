using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using App.Data.Entities;

namespace App.Data
{
    public class XmlDbContext : IDbContext
    {
        private readonly string _name;
        private readonly XmlSerializer _ser;

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("summoner")]
        public List<SummonerDto> Summoners { get; } = new List<SummonerDto>();

        [XmlArray("champions")]
        public List<ChampionDto> Champions { get; set; } = new List<ChampionDto>();
        

        public XmlDbContext() { }

        public XmlDbContext(string name) 
        {
            _name = name;
            using (var db = File.Open(_name, FileMode.Open))
            {
                _ser = new XmlSerializer(typeof(XmlDbContext));
                var des = _ser.Deserialize(db) as XmlDbContext;
                Summoners = des.Summoners;
            }            
        }

        public async Task SaveChangesAsync() => await Task.Run(() => 
        {
            using (var db = File.Open(_name, FileMode.Open))
            {
                _ser.Serialize(db, this);
            } 
        });
    }
}