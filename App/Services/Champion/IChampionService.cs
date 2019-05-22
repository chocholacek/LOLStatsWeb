using System.Collections.Generic;
using System.Threading.Tasks;
using App.Data.Entities;

namespace App.Services.Champion
{
    public interface IChampionService
    {
        Task<ChampionDto> GetChampionAsync(int id);

        Task<List<ChampionDto>> FreeChampionsAsync();
    }
}