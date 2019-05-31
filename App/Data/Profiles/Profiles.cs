using App.Data.Entities;
using AutoMapper;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Endpoints.MatchEndpoint;
using System.Linq;
using RiotSharp.Endpoints.ChampionEndpoint;
using RiotSharp.Endpoints.LeagueEndpoint;

namespace App.Data.Profiles
{
    public class DtoProfiles : Profile
    {
        public DtoProfiles()
        {
            CreateMap<Summoner, SummonerDto>()
                .ForMember(dest => dest.SummonerId, src => src.MapFrom(s => s.Id));

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
                .ForMember(dest => dest.Won, 
                    m => m.MapFrom(src => src.Teams.First(t => t.Win == "Win").TeamId));

            CreateMap<Champion, ChampionDto>();

            CreateMap<LeaguePosition, LeagueDto>()
                .ForMember(dest => dest.Winrate, m => m .MapFrom(src => (double)src.Wins / (src.Wins + src.Losses)));
        }
    }
}