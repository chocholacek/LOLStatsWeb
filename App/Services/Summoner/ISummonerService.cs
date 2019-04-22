using System.Threading.Tasks;
using App.Models;

namespace App.Services.Summoner
{
    public interface ISummonerService
    {
        Task<SummonerDto> GetSummonerAsync(string name);
    }
}