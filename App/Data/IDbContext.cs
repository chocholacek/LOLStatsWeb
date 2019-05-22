using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Data.Entities;

namespace App.Data
{
    public interface IDbContext
    {
        string Version { get; set; }

        List<SummonerDto> Summoners { get; }

        List<ChampionDto> Champions { get; set; }

        Task SaveChangesAsync();
    }
}