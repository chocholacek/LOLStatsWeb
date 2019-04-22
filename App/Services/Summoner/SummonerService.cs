using System.Threading.Tasks;
using App.Models;
using AutoMapper;
using RiotSharp;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace App.Services.Summoner
{
    public class SummonerService : ISummonerService
    {
        private readonly IRiotApi _api;
        private readonly IMapper _mapper;

        public SummonerService(IRiotApi api, IMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        public async Task<SummonerDto> GetSummonerAsync(string name)
        {
            try
            {
                var sum = await _api.Summoner.GetSummonerByNameAsync(Region.Eune, name);
                return _mapper.Map<SummonerDto>(sum);
            }
            catch (RiotSharpException)
            {            
                return null;
            }
            
        }
    }
}