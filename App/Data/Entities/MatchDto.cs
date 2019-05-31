using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace App.Data.Entities
{
    public class MatchDto
    {
        [XmlElement("dur")]
        public TimeSpan GameDuration { get; set; }

        [XmlElement("participant")]
        public List<ParticipantDto> Participants { get; set; }

        [XmlAttribute("w")]
        public bool Won {get; set;}

        [XmlElement("at")]
        public DateTime GameCreation { get; set; }

/*
        public bool Won(string name)
        {
            var team = Participants.First(p => p.SummonerName == name).TeamId;
            return team == WinningTeam;
        }
        */
    }
}