using System.Threading.Tasks;
using App.Data.Entities;

namespace App.Services.Summoner
{
    public interface ISummonerService
    {
        Task<SummonerDto> GetSummonerAsync(string name);

        Task<SummonerDto> UpdateSummonerAsync(string name);
    }
}