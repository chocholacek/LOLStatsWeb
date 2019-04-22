using AutoMapper;
using RiotSharp.Endpoints.SummonerEndpoint;

namespace App.Models.Profiles
{
    public class DtoProfiles : Profile
    {
        public DtoProfiles()
        {
            CreateMap<Summoner, SummonerDto>();
        }
    }
}