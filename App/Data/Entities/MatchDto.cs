using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace App.Data.Entities
{
    public class MatchDto
    {
        [XmlElement("duration")]
        public TimeSpan GameDuration { get; set; }

        [XmlElement("participant")]
        public List<ParticipantDto> Participants { get; set; }

        [XmlAttribute("w")]
        public int WinningTeam {get; set;}

        public bool Won(string name)
        {
            var team = Participants.First(p => p.SummonerName == name).TeamId;
            return team == WinningTeam;
        }
    }
}