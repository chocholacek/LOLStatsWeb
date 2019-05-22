using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Entities;
using App.Services.Base;
using AutoMapper;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace App.Services.Champion
{
    public class ChampionService : ServiceBase, IChampionService
    { 
        public ChampionService(IRiotApi api, IMapper mapper, IDbContext db)
            : base(api, mapper, db) {}

        public async Task<List<ChampionDto>> FreeChampionsAsync()
        {
            await UpdateAsync();
            var free = await Api.Champion.GetChampionRotationAsync(Region.Eune);
            return Db.Champions.Where(c => free.FreeChampionIds.Contains((int)c.Id))
                .ToList();
        }

        public async Task<ChampionDto> GetChampionAsync(int id)
        {
            await UpdateAsync();
            return Db.Champions.First(c => c.Id == id);
        }

        private async Task UpdateAsync()
        {
            var versions = await Api.StaticData.Versions.GetAllAsync();
            var current = versions.First();
            if (current != Db.Version)
            {
                var data = await Api.StaticData.Champions.GetAllAsync(current);
                
                Db.Version = current;
                Db.Champions = data.Champions
                    .Select(c => new ChampionDto
                    {
                        Id = c.Value.Id,
                        Key = c.Value.Key,
                        Name = c.Value.Name,
                        Image = c.Value.Image.Full
                    })
                    .ToList();
                await Db.SaveChangesAsync();
            }
        }

        private void UpdateChampions()
        {
            throw new NotImplementedException();
        }
    }
}