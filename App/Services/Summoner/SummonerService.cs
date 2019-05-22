using System.Linq;
using System.Threading.Tasks;
using App.Data;
using AutoMapper;
using RiotSharp;
using RiotSharp.Interfaces;
using RiotSharp.Misc;
using App.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using App.Services.Base;

namespace App.Services.Summoner
{
    public class SummonerService : ServiceBase, ISummonerService
    {

        public SummonerService(IRiotApi api, IMapper mapper, IDbContext db)
            : base(api, mapper, db) {}
            
        public async Task<SummonerDto> GetSummonerAsync(string name)
        {
            var sum = Db.Summoners.FirstOrDefault(s => s.Name == name);
            if (sum == null)
            {
                try
                {
                    var end = await Api.Summoner.GetSummonerByNameAsync(Region.Eune, name);
                    sum = Mapper.Map<SummonerDto>(end);
                    Db.Summoners.Add(sum);
                    await Db.SaveChangesAsync();
                }
                catch (RiotSharpException)
                {
                    return null;
                }
            }
            return sum;
        }

        public async Task<SummonerDto> UpdateSummonerAsync(string name)
        {
            var dto = Db.Summoners.First(s => s.Name == name);
            var games = await Api.Match.GetMatchListAsync(Region.Eune, dto.AccountId);
            var matches = games.Matches
                .OrderByDescending(m => m.Timestamp)
                .Take(10)
                .Select(m => Api.Match.GetMatchAsync(Region.Eune, m.GameId).Result)
                .ToList();
            
            dto.Matches = Mapper.Map<List<MatchDto>>(matches);
            await Db.SaveChangesAsync();
            return dto;
        }
    }
}