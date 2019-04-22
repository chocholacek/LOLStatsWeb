using System;
using System.Threading.Tasks;
using App.Models;
using App.Services.Summoner;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace App.Controllers
{
    public class SummonerController : Controller
    {
        private readonly ISummonerService _service;

        public SummonerController(ISummonerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string name)
        {
            var summoner = await _service.GetSummonerAsync(name);

            if (summoner == null)
                return NotFound();

            return View(summoner);
        }
    }
}