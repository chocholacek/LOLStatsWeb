using System;
using System.Threading.Tasks;
using App.Services.Champion;
using Microsoft.AspNetCore.Mvc;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace App.Controllers
{
    public class ChampionsController : Controller
    {
        private readonly IChampionService _service;

        public ChampionsController(IChampionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Free()
        {
            return View(await _service.FreeChampionsAsync());
        }
    }
}