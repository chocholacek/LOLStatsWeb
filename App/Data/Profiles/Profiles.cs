using App.Data.Entities;
using AutoMapper;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Endpoints.MatchEndpoint;
using System.Linq;
using RiotSharp.Endpoints.ChampionEndpoint;

namespace App.Data.Profiles
{
    public class DtoProfiles : Profile
    {
        public DtoProfiles()
        {
            CreateMap<Summoner, SummonerDto>();

            object selector(Match match, MatchDto dto)
            {
                var identities = match.ParticipantIdentities;
                var pars = match.Participants;
                var merged = identities.Join(pars,
                    i => i.ParticipantId,
                    p => p.ParticipantId,
                    (i, p) => new ParticipantDto
                    {
                        SummonerName = i.Player.SummonerName,
                        ChampionId = p.ChampionId,
                        TeamId = p.TeamId
                    });

                return merged;
            }

            CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.Participants, m => m.MapFrom(selector))
                .ForMember(dest => dest.WinningTeam, 
                    m => m.MapFrom(src => src.Teams.First(t => t.Win == "Win").TeamId));

            CreateMap<Champion, ChampionDto>();
        }
    }
}