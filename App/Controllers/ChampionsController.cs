using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace App.Controllers
{
    public class ChampionsController : Controller
    {
        private readonly IRiotApi _api;

        public ChampionsController(IRiotApi api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> Free()
        {
            var champs = await _api.Champion.GetChampionRotationAsync(Region.Eune);
            var data = await _api.StaticData.Champions.GetAllAsync("9.5");
            throw new NotImplementedException();
        }
    }
}